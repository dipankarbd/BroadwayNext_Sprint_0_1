var bn = bn || {};

bn.Division = function (data) {
    var self = this;
    self.DivisionID = ko.observable(data.DivisionID);
    self.Code = ko.observable(data.Code);
    self.Prefix = ko.observable(data.Prefix);
    self.GLNum = ko.observable(data.GLNum);
    self.Address1 = ko.observable(data.Address1);
    self.Address2 = ko.observable(data.Address2);
    self.City = ko.observable(data.City);
    self.State = ko.observable(data.State);
    self.Zip = ko.observable(data.Zip);
    self.Phone = ko.observable(data.Phone);
    self.Fax = ko.observable(data.Fax);
    self.ComplaintEmail = ko.observable(data.ComplaintEmail);
    self.VendorInstructions = ko.observable(data.VendorInstructions);
    self.AutofaxNotice = ko.observable(data.AutofaxNotice);
    self.Inputdate = ko.observable(moment(data.InputDate).toDate());
    self.InputBy = ko.observable(data.InputBy);
};
bn.TerminationReason = function (data) {
    var self = this;
    self.TerminationReasonID = ko.observable(data.TerminationReasonID);
    self.Code = ko.observable(data.Code);
    self.Inputdate = ko.observable(moment(data.InputDate).toDate());
    self.InputBy = ko.observable(data.InputBy);
};
bn.VendorTermination = function (data) {
    var self = this;

    self.VendorTerminationID = ko.observable(data.VendorTerminationID);
    self.VendorID = ko.observable(data.VendorID);
    self.TerminationDate = ko.observable(moment(data.TerminationDate).toDate());
    self.TerminationDate.formatted = moment(data.TerminationDate).format("MM/DD/YYYY");
    self.TerminationEffDate = ko.observable(moment(data.TerminationEffDate).toDate());
    self.TerminationEffDate.formatted = moment(data.TerminationEffDate).format("MM/DD/YYYY");
    self.TerminatedBy = ko.observable(data.TerminatedBy);
    self.TerminationReason = ko.observable(data.TerminationReason);
    self.TerminationReasonText = ko.observable(data.TerminationReasonText);
    self.Rehire = ko.observable(data.Rehire);
    self.Division = ko.observable(data.Division);
    self.DivisionText = ko.observable(data.DivisionText);
    self.InputBy = ko.observable(data.InputBy);
    self.InputDate = ko.observable(moment(data.InputDate).toDate());
    self.LastModifiedBy = ko.observable(data.LastModifiedBy);
    self.LastModifiedDate = ko.observable(moment(data.LastModifiedDate).toDate());
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

       reasons = ko.observableArray([]),
       divisions = ko.observableArray([]),

       fetchTerminations = function () {
           if (vendorId()) {
               //Console.log('will fetch termination now');
               $.getJSON("/vendorlisting/getvendorterminations", { vendorId: vendorId(), pageSize: terminationsGridPageSize(), currentPage: terminationsGridCurrentPage() }, function (result) {
                   totalTerminations(result.VirtualRowCount);
                   terminationsGridTotalPages(Math.ceil(result.VirtualRowCount / terminationsGridPageSize()));
                   var mappedTerminations = $.map(result.Data, function (item) {
                       var division = new bn.Division(item.Division1);
                       var termination = new bn.Division(item.TerminationReason1);
                       item.DivisionText = division.Code();
                       item.TerminationReasonText = termination.Code();
                       item.Rehire = item.Rehire === '1' ? true : false;
                       return new bn.VendorTermination(item);
                   });
                   terminations(mappedTerminations);
                   //set the Tab counter
                   var tabName = 'Termination';
                   $('#tabstwo li:eq(10) a').html(tabName);
                   if (totalTerminations() > 0) {
                       tabName = tabName + '(' + totalTerminations() + ')';
                       $('#tabstwo li:eq(10) a').html(tabName);
                   }
               });
           }
       },
       //To Do : make sure we fetch reasons only once...
       fetchReasons = function () {
           $.getJSON("/vendorlisting/getreasons", function (result) {
               var mappedReasons = $.map(result.Data, function (item) {
                   return new bn.TerminationReason(item);
               });
               reasons(mappedReasons);
           });
       },
       fetchDivisions = function () {
           $.getJSON("/vendorlisting/getdivisions", function (result) {
               var mappedDivisions = $.map(result.Data, function (item) {
                   return new bn.Division(item);
               });

               divisions(mappedDivisions);
           });
       },

       selectedTermination = ko.observable(),
       editingTermination = ko.observable(),

       selectTermination = function (termination) {
           //Console.log('select termination');
           selectedTermination(termination);
       },

       addNewTermination = function () {
           //Console.log('Adding new termination for vendor: ' + vendorId());
           editingTermination(new bn.VendorTermination({ VendorID: vendorId() }));
           ko.editable(editingTermination());
           editingTermination().beginEdit();
       },

       editTermination = function () {
           //Console.log('Will edit termination now');
           editingTermination(selectedTermination());
           ko.editable(editingTermination());
           editingTermination().beginEdit();
       },

       prepareModal = function () {
           //initialize datepicker here
       },

       saveTermination = function () {
           //Console.log('saving termination...');
           editingTermination().commit();

           $.ajax("/vendorlisting/savevendortermination", {
               data: ko.toJSON({ termination: editingTermination() }),
               type: "post", contentType: "application/json",
               success: function (result) {
                   selectedTermination(undefined);
                   editingTermination(undefined);
                   if (result.Success === true) {
                       fetchTerminations();
                       toastr.success("Termination information updated successfully", "Success");
                       $("#modal-termination").modal("hide");
                   }
               }
           });
       },

       deleteTermination = function () {
           if (confirm('Are you sure you want to delete this termination?')) {
               $.ajax("/vendorlisting/deletevendortermination", {
                   data: ko.toJSON({ termination: selectedTermination() }),
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
       editVendor = function () {
           amplify.publish("EditVendor");
       },
    //subscribe to receive Selected Vendor ID & Num
       onVendorSelectionChanged = function (id, num) {
           if (id) {
               vendorId(id);
               vendorNum = num;
               if (id) {
                   fetchTerminations();    //Re-load on valid ID  
                   if (!reasons().length)    //Load if empty
                       fetchReasons();
                   if (!divisions().length)  //Load if empty
                       fetchDivisions();
               }

           }
       },

       cancelEdit = function () {
           editingTermination().rollback();
           $("#modal-termination").modal("hide");
       };

    return {
        fetchTerminations: fetchTerminations,
        addNewTermination: addNewTermination,
        editTermination: editTermination,
        saveTermination: saveTermination,
        deleteTermination: deleteTermination,
        cancelEdit: cancelEdit,

        selectTermination: selectTermination,
        editingTermination: editingTermination,
        selectedTermination: selectedTermination,
        vendorSelectionChanged: onVendorSelectionChanged,

        reasons: reasons,
        divisions: divisions,
        vendorId: vendorId,
        terminations: terminations,

        totalTerminations: totalTerminations,

        terminationsGridPageSize: terminationsGridPageSize,
        terminationsGridTotalPages: terminationsGridTotalPages,
        terminationsGridCurrentPage: terminationsGridCurrentPage,
        editVendor: editVendor,
        prepareModal: prepareModal
    };
})(jQuery, bn);

$(function () {
    //Set up subscription
    amplify.subscribe("VendorSelectionChanged", function (vID, vNum) {
        //Console.log(vID);
        bn.vmTerminationList.vendorSelectionChanged(vID, vNum);
    });
    bn.vmTerminationList.fetchTerminations();
});
