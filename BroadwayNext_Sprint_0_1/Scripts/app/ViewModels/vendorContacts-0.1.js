var bn = bn || {};

bn.VendorContact = function (data) {
    var self = this;
    self.VendorContactID = ko.observable(data.VendorContactID);
    self.VendorID = ko.observable(data.VendorID);
    self.Lastname = ko.observable(data.Lastname);
    self.Firstname = ko.observable(data.Firstname);
    self.Address1 = ko.observable(data.Address1);
    self.Address2 = ko.observable(data.Address2);
    self.City = ko.observable(data.City);
    self.State = ko.observable(data.State);
    self.Zip = ko.observable(data.Zip);
    self.Phone = ko.observable(data.Phone);
    self.PhoneExt = ko.observable(data.PhoneExt);
    self.Fax = ko.observable(data.Fax);
    self.Mobile = ko.observable(data.Mobile);
    self.Title = ko.observable(data.Title);
    self.ContactType = ko.observable(data.ContactType);
    self.Email = ko.observable(data.Email);
    self.Notes = ko.observable(data.Notes);
    self.ActiveType = ko.observable(data.ActiveType);
    self.InputDate = ko.observable(data.InputDate);
    self.InputBy = ko.observable(data.InputBy);
    self.LastModifiedDate = ko.observable(data.LastModifiedDate);
    self.LastModifiedBy = ko.observable(data.LastModifiedBy);
    self.Vendnum = ko.observable(data.Vendnum);
    self.IsActive = ko.computed(function () {
        if (self.ActiveType() === 'true') return 'Yes';
        else return 'No';
    });
    self.InputDateFormated = ko.computed(function () {
        if (self.InputDate() != undefined) {
            var value = new Date(parseInt(self.InputDate().replace("/Date(", "").replace(")/", ""), 10));
            var ret = value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
            return ret;
        }
        else return "";
    });
};

bn.vmContactList = (function ($, bn, undefined) {
    var
        self = this,
        vendorId = ko.observable(),
        vendorNum,
        contacts = ko.observableArray([]),
        totalContacts = ko.observable(0),

        contactsGridPageSize = ko.observable(10),
        contactsGridTotalPages = ko.observable(0),
        contactsGridCurrentPage = ko.observable(1),



        fetchContacts = function () {
            if (vendorId()) {
                console.log('will fetch contact now');
                $.getJSON("/vendorlisting/getvendorcontacts", { vendorId: vendorId(), pageSize: contactsGridPageSize(), currentPage: contactsGridCurrentPage() }, function (result) {
                    totalContacts(result.VirtualRowCount);
                    contactsGridTotalPages(Math.ceil(result.VirtualRowCount / contactsGridPageSize()));
                    var mappedContacts = $.map(result.Data, function (item) { return new bn.VendorContact(item); });
                    contacts(mappedContacts);
                });
            }
        },

        countries = ["USA", "Canada"],
        states = ["WI", "MT", "MD"],

        selectedContact = ko.observable(),
        editingContact = ko.observable(),
        selectContact = function (contact) {
            console.log('contact selected');
            selectedContact(contact);
            
            prepareModalDialog();   //prepare the UI dialog
        },

        addNewContact = function () {
            console.log('Adding new contact for vendor: ' + vendorId());
            editingContact(new bn.VendorContact({ VendorID: vendorId() }));
            ko.editable(editingContact());
            editingContact().beginEdit();
            
            prepareModalDialog();
            $("#dialog-contact").dialog("open");
        },

        prepareModalDialog = function () {
            $("#dialog-contact").dialog({
                autoOpen: false,
                height: 730,
                width: 500,
                modal: true,
                focus: function (event, ui) {
                    //var l = $('#contactphone').length;
                    //console.log('inside FOCUS --> contactPhone : ' + l);
                    $('#contactphone').mask("(999) 999-9999");
                    $('#contactfax').mask("(999) 999-9999");
                }
            });
        },

        editContact = function () {
            console.log('Will edit contact now');
            editingContact(selectedContact());
            ko.editable(editingContact());
            editingContact().beginEdit();
            $("#dialog-contact").dialog("open");
        },

        saveContact = function () {
            console.log('saving contact...');
            editingContact().commit();

            $.ajax("/vendorlisting/savevendorcontact", {
                data: ko.toJSON({ contact: editingContact() }),
                type: "post", contentType: "application/json",
                success: function (result) {
                    selectedContact(undefined);
                    editingContact(undefined);
                    if (result.Success === true) {
                        fetchContacts();
                        toastr.success("Contact information updated successfully", "Success");
                        $("#dialog-contact").dialog("close");
                    }
                }
            });
        },

        editVendor = function () {
            amplify.publish("EditVendor");
        },

        //subscribe to receive Selected Vendor ID & Num
        onVendorSelectionChanged = function (id, num) {
            if (id) {
                vendorId(id);
                vendorNum = num;
                if (id)
                    fetchContacts();    //Re-load on valid ID  
            }

            //console.log(vendorId() + " -- " + vendorNum);
        },

        cancelEdit = function () {
            editingContact().rollback();
            $("#dialog-contact").dialog("close");
        };




    return {

        fetchContacts: fetchContacts,
        addNewContact: addNewContact,
        editContact: editContact,
        saveContact: saveContact,
        cancelEdit: cancelEdit,

        selectContact: selectContact,
        editingContact: editingContact,
        selectedContact: selectedContact,
        vendorSelectionChanged: onVendorSelectionChanged,

        countries: countries,
        states: states,
        vendorId: vendorId,
        contacts: contacts,

        totalContacts: totalContacts,
        contactsGridPageSize: contactsGridPageSize,
        contactsGridTotalPages: contactsGridTotalPages,
        contactsGridCurrentPage: contactsGridCurrentPage,
        editVendor: editVendor

    };


})(jQuery, bn);



$(function () {

    //Set up subscription
    amplify.subscribe("VendorSelectionChanged", function (vID, vNum) {
        console.log(vID);
        bn.vmContactList.vendorSelectionChanged(vID, vNum);
    });

    bn.vmContactList.fetchContacts();

    ////$('#dialog-contact').on('focus', '#contactphone',function () {
    ////     console.log('found it');
    ////});
    //$("#dialog-contact").dialog({
    //    //autoOpen: false,
    //    //height: 730,
    //    //width: 500,
    //    //modal: false,
    //    create: function (event, ui) {
    //        console.log('tab being created...');
    //        alert("Created");
    //    },
    //    open: function (event, ui) {
    //        console.log('tab being created...');
    //        alert("Created");
    //    }
    //})

        
});
