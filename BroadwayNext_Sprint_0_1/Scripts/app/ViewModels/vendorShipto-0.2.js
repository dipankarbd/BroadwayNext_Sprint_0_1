var bn = bn || {};

bn.VendorShipTo = function (data) {
    var self = this;
    self.VendorShipToID = ko.observable(data.VendorShipToID);
    self.VendorID = ko.observable(data.VendorID);
    self.Recipient = ko.observable(data.Recipient);
    self.Address1 = ko.observable(data.Address1);
    self.Address2 = ko.observable(data.Address2);
    self.City = ko.observable(data.City);
    self.State = ko.observable(data.State);
    self.Zip = ko.observable(data.Zip);
    self.Country = ko.observable(data.Country);
    self.Province = ko.observable(data.Province);
    self.Phone = ko.observable(data.Phone);
    self.PhoneExt = ko.observable(data.PhoneExt);
    self.Fax = ko.observable(data.Fax);
    self.Email = ko.observable(data.Email);
    self.InputDate = ko.observable(moment(data.InputDate).toDate());
    self.InputDate.formatted = moment(data.InputDate).format("MM/DD/YYYY");
    self.InputBy = ko.observable(data.InputBy);
    self.LastModifiedDate = ko.observable(moment(data.LastModifiedDate).toDate());
    self.LastModifiedBy = ko.observable(data.LastModifiedBy);
};

bn.vmShipToList = (function ($, bn, undefined) {
    var
        self = this,
        vendorId = ko.observable(),
        vendorNum,
        shipTos = ko.observableArray([]),
        totalShipTos = ko.observable(0),

        shipTosGridPageSize = ko.observable(10),
        shipTosGridTotalPages = ko.observable(0),
        shipTosGridCurrentPage = ko.observable(1),
        fetchShipTos = function () {
            if (vendorId()) {
                //console.log('will fetch shipto now');
                $.getJSON("/vendorlisting/getvendorshiptos", { vendorId: vendorId(), pageSize: shipTosGridPageSize(), currentPage: shipTosGridCurrentPage() }, function (result) {
                    totalShipTos(result.VirtualRowCount);
                    shipTosGridTotalPages(Math.ceil(result.VirtualRowCount / shipTosGridPageSize()));
                    var mappedShipTos = $.map(result.Data, function (item) { return new bn.VendorShipTo(item); });
                    shipTos(mappedShipTos);
                    //set the Tab counter
                    var tabName = 'Ship To';
                    $('#tabstwo li:eq(6) a').html(tabName);
                    if (totalShipTos() > 0) {
                        tabName = tabName + '(' + totalShipTos() + ')';
                        $('#tabstwo li:eq(6) a').html(tabName);
                    }
                });
            }
        },

        countries = ["USA", "Canada"],
        states = ["WI", "MT", "MD"],

        selectedShipTo = ko.observable(),
        editingShipTo = ko.observable(),

        selectShipTo = function (shiptto) {
            console.log('shipto selected');
            selectedShipTo(shiptto);
        },

       addNewShipTo = function () {
           console.log('Adding new shipto for vendor: ' + vendorId());
           editingShipTo(new bn.VendorShipTo({ VendorID: vendorId() }));
           ko.editable(editingShipTo());
           editingShipTo().beginEdit();
       },

       editShipTo = function () {
           console.log('Will edit shipto now');
           editingShipTo(selectedShipTo());
           ko.editable(editingShipTo());
           editingShipTo().beginEdit();
       },

        prepareModal = function () {
            console.log('#shiptophone: ' + $('#shiptophone').val());
            $('#shiptophone').mask("(999) 999-9999");
            $('#shiptofax').mask("(999) 999-9999");
        },
        saveShipTo = function () {
            console.log('saving shipto...');
            editingShipTo().commit();

            $.ajax("/vendorlisting/savevendorshipto", {
                data: ko.toJSON({ shipto: editingShipTo() }),
                type: "post", contentType: "application/json",
                success: function (result) {
                    selectedShipTo(undefined);
                    editingShipTo(undefined);
                    if (result.Success === true) {
                        fetchShipTos();
                        toastr.success("Shipt To information updated successfully", "Success");
                        //$("#dialog-shipto").dialog("close");
                        $("#modal-shipto").modal("hide");
                    }
                }
            });
        },

         deleteShipTo = function () {
             if (confirm('Are you sure you want to delete this ship to address?')) {
                 $.ajax("/vendorlisting/deletevendorshipto", {
                     data: ko.toJSON({ shipto: selectedShipTo() }),
                     type: "post", contentType: "application/json",
                     success: function (result) {
                         selectedShipTo(undefined);
                         if (result.Success === true) {
                             fetchShipTos();
                             toastr.success("Ship to information deleted successfully", "Success");
                         }
                     }
                 });
             }
         },

        //subscribe to receive Selected Vendor ID & Num
        onVendorSelectionChanged = function (id, num) {
            if (id) {
                vendorId(id);
                vendorNum = num;
                if (id)
                    fetchShipTos();    //Re-load on valid ID  
            }
            //console.log(vendorId() + " -- " + vendorNum);
        },

        cancelEdit = function () {
            editingShipTo().rollback();
            $("#modal-shipto").modal("hide");
        };

    return {
        fetchShipTos: fetchShipTos,
        addNewShipTo: addNewShipTo,
        editShipTo: editShipTo,
        saveShipTo: saveShipTo,
        deleteShipTo: deleteShipTo,
        cancelEdit: cancelEdit,

        selectShipTo: selectShipTo,
        editingShipTo: editingShipTo,
        selectedShipTo: selectedShipTo,
        vendorSelectionChanged: onVendorSelectionChanged,

        countries: countries,
        states: states,
        vendorId: vendorId,
        shipTos: shipTos,

        totalShipTos: totalShipTos,
        shipTosGridPageSize: shipTosGridPageSize,
        shipTosGridTotalPages: shipTosGridTotalPages,
        shipTosGridCurrentPage: shipTosGridCurrentPage,
        prepareModal: prepareModal
    };
})(jQuery, bn);

$(function () {
    //Set up subscription
    amplify.subscribe("VendorSelectionChanged", function (vID, vNum) {
        console.log(vID);
        bn.vmShipToList.vendorSelectionChanged(vID, vNum);
    });
    bn.vmShipToList.fetchShipTos();
});
