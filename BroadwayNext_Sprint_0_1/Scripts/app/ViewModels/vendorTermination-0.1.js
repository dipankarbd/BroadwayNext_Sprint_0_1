var bn = bn || {};

bn.VendorTermination = function (data) {
    var self = this;

    self.VendorTerminationID = ko.observable(data.VendorTerminationID);
    self.VendorID = ko.observable(data.VendorID);
    self.TerminationDate = ko.observable(data.TerminationDate);
    self.TerminationEffDate = ko.observable(data.TerminationEffDate);
    self.TerminatedBy = ko.observable(data.TerminatedBy);
    self.TerminationReason = ko.observable(data.TerminationReason);
    self.Rehire = ko.observable(data.Rehire);
    self.Division = ko.observable(data.Division);
    self.InputBy = ko.observable(data.InputBy);
    self.InputDate = ko.observable(data.InputDate);
    self.LastModifiedBy = ko.observable(data.LastModifiedBy);
    self.LastModifiedDate = ko.observable(data.LastModifiedDate);
};

bn.vmTerminationList = (function ($, bn, undefined) {
    var
        self = this,
    vendorId = ko.observable(),
       vendorNum,
       terminations = ko.observableArray([]),
       totalTerminations = ko.observable(0),

       terminationsGridPageSize = ko.observable(10),
       terminationsGridTotalPages = ko.observable(0),
       terminationsGridCurrentPage = ko.observable(1),
       fetchTerminations = function () {
           if (vendorId()) {
               console.log('will fetch termination now');
               $.getJSON("/vendorlisting/getvendorterminations", { vendorId: vendorId(), pageSize: terminationsGridPageSize(), currentPage: terminationsGridCurrentPage() }, function (result) {
                   totalTerminations(result.VirtualRowCount);
                   terminationsGridTotalPages(Math.ceil(result.VirtualRowCount / terminationsGridPageSize()));
                   var mappedTerminations = $.map(result.Data, function (item) { return new bn.VendorTermination(item); });
                   terminations(mappedTerminations);
               });
           }
       },
       reasons = ["Reason 1", "Reason 2", "Reason 3"],
       rehires = ["A", "B", "C"],
       divisions = [{ "id": 1, "name": "Division 1" }, { "id": 2, "name": "Division 2" }, { "id": 3, "name": "Division 3" }],

       selectedTermination = ko.observable(),
       editingTermination = ko.observable(),

       selectTermination = function (termination) {
           console.log('shipto termination');
           selectedTermination(termination);

           prepareModalDialog();   //prepare the UI dialog
       },

       addNewTermination = function () {
           console.log('Adding new termination for vendor: ' + vendorId());
           editingTermination(new bn.VendorTermination({ VendorID: vendorId() }));
           ko.editable(editingTermination());
           editingTermination().beginEdit();

           prepareModalDialog();
           $("#dialog-termination").dialog("open");
       },

       editTermination = function () {
           console.log('Will edit termination now');
           editingTermination(selectedTermination());
           ko.editable(editingTermination());
           editingTermination().beginEdit();
           $("#dialog-termination").dialog("open");
       },

       prepareModalDialog = function () {
           $("#dialog-termination").dialog({
               autoOpen: false,
               height: 730,
               width: 500,
               modal: true,
               focus: function (event, ui) {
               }
           });
       },

       saveTermination = function () {
           console.log('saving termination...');
           editingTermination().commit();

           $.ajax("/vendorlisting/savevendortermination", {
               data: ko.toJSON({ shipto: editingTermination() }),
               type: "post", contentType: "application/json",
               success: function (result) {
                   selectedTermination(undefined);
                   editingTermination(undefined);
                   if (result.Success === true) {
                       fetchTerminations();
                       toastr.success("Termination information updated successfully", "Success");
                       $("#dialog-termination").dialog("close");
                   }
               }
           });
       },

       deleteTermination = function () {
           if (confirm('Are you sure you want to delete this termination?')) {
               $.ajax("/vendorlisting/deletevendortermination", {
                   data: ko.toJSON({ shipto: selectedTermination() }),
                   type: "post", contentType: "application/json",
                   success: function (result) {
                       selectedTermination(undefined);
                       if (result.Success === true) {
                           fetchTerminations();
                           toastr.success("Termination information deleted successfully", "Success");
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
                   fetchTerminations();    //Re-load on valid ID  
           }
       },

       cancelEdit = function () {
           editingShipTo().rollback();
           $("#dialog-termination").dialog("close");
       };

    return {
        fetchTerminations: fetchTerminations,
        addNewTermination: addNewTermination,
        editTermination: editTermination,
        saveTermination: saveTermination,
        deleteTermination: deleteTermination,
        cancelEdit: cancelEdit,

        selectShipTo: selectShipTo,
        editingShipTo: editingShipTo,
        selectedTermination: selectedTermination,
        vendorSelectionChanged: onVendorSelectionChanged,

        reasons: reasons,
        rehires: rehires,
        divisions: divisions,
        vendorId: vendorId,
        terminations: terminations,

        totalTerminations: totalTerminations,

        terminationsGridPageSize: terminationsGridPageSize,
        terminationsGridTotalPages: terminationsGridTotalPages,
        terminationsGridCurrentPage: terminationsGridCurrentPage
    };
})(jQuery, bn);

$(function () {
    //Set up subscription
    amplify.subscribe("VendorSelectionChanged", function (vID, vNum) {
        console.log(vID);
        bn.vmTerminationList.vendorSelectionChanged(vID, vNum);
    });
    bn.vmTerminationList.fetchTerminations();
});
