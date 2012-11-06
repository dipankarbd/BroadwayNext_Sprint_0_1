/*
// Version : 0.8

Goal ==> Simple , Manual Model + Manual Map + Validation + Tracking

Result: ==> 

Next Version ==> 


*/

var bn = bn || {};

//#region
/*
VendorID: "7bfbadb3-e64b-0691-7dc9-002012a97909"
Vendnum: 1578511699
Company: "Frodudefin International Inc"
DBA: "EDKM8LA5I0Y9OOGEMQGG9ORI0AF50AO"
Address1: "22 West First Boulevard"
Address2: "110 Rocky Hague Freeway"
City: "Des Moines"
State: "South Carolina"
Zip: "32702"
Country: "Western Sahara"

/-- Insurance
"VendorInsurances": [
        {
          "VendorInsuranceID": "55dfb2b7-c6a7-bb51-2330-f5e69d1ed867",
          "VendorID": "1d3b4a68-4917-87ec-11db-005add3f5006",
          "InsuranceType": -1063312015,
          "InsuranceName": "Lillian957",
          "Policynum": -6900418022880996000,
          "ExpiryDate": "/Date(-57823200000)/",
          "AdditionalInsured": false,
          "Not_onFile": false,
          "InsuranceNotRequired": false,
          "NotRequiredReason": "plorum linguens parte linguens vobis quis quoque apparens linguens vantis. si glavans non vantis. et",
          "InputBy": "OEOZWEE372J6BQF2M1Q6KAFSMFAO5IZ",
          "InputDate": "08-09-1959",
          "LastModifiedBy": "MNHC4BHX7MEIKKBR6BAD53F1XEF09K7R",
          "LastModifiedDate": "/Date(1000663200000)/"
        },
//------------
/-- REMIT TO
"VendorRemitToID": "7f861727-0b7a-fecc-62b5-cc67041adf27",
        "VendorID": "1d3b4a68-4917-87ec-11db-005add3f5006",
        "Company": "Tippebicator Direct ",
        "RemitType": "quad regit, essit. quo quoque quantare in et",
        "Address1": "93 Second Way",
        "Address2": "90 South First Freeway",
        "City": "dhaka",
        "State": "Nevada",
        "Zip": "29201",
///---------
*/

//bn.RemitTo = function (data) {
//    this.VendorRemitToID = ko.observable(data.VendorRemitToID);
//    this.VendorID = ko.observable(data.VendorID);
//    this.Company = ko.observable(data.Company);
//    this.RemitType = ko.observable(data.RemitType);
//    this.City = ko.observable(data.City);
//    this.Address1 = ko.observable();
//}

//bn.Vendor = function (data) {
//    this.VendorID = ko.observable(data.VendorID);
//    this.Vendnum = ko.observable(data.Vendnum);
//    this.Company = ko.observable(data.Company).extend({ required: true });
//    this.Address1 = ko.observable(data.address1);
//    this.City = ko.observable(data.City);
//    this.State = ko.observable(data.State);
//    this.Zip = ko.observable(data.Zip);
//    this.Phone = ko.observable(data.Phone);
//    this.InputDate = ko.observable(data.InputDate);
//    this.DBA = ko.observable(data.DBA);
//    //this.VendorType = ko.observable(data.VendorType);
//    //this.isActive = ko.observable();

//    this.VendorRemitToes = ([]);
//};
//#endregion


bn.Insurance = function (data) {

};

//#region "MODEL"
bn.RemitTo = function (data) {
    this.VendorRemitToID = ko.observable(data.VendorRemitToID);
    this.VendorID = ko.observable(data.VendorID);
    this.Company = ko.observable(data.Company);
    this.RemitType = ko.observable(data.RemitType);
    this.Address1 = ko.observable(data.Address1);
    this.Address2 = ko.observable(data.Address2);
    this.City = ko.observable(data.City);
    this.State = ko.observable(data.State);
    this.Zip = (data.zip) ? ko.observable(data.Zip) : ko.observable();
    this.Country = ko.observable(data.Country);
    this.Province = ko.observable(data.Province);
    this.Phone = ko.observable(data.Phone);
    this.PhoneExt = ko.observable(data.PhoneExt);
    this.Contact = ko.observable(data.Contact);
    this.Email = ko.observable(data.Email);
    this.InputBy = ko.observable(data.InputBy);
    //var date = moment(data.InputDate).format("MM-DD-YYYY");
    this.InputDate = ko.observable(data.InputDate);
    this.LastModifiedBy = ko.observable(data.LastModifiedBy);
    this.LastModifiedDate = ko.observable(data.LastModifiedDate);
    this.Edited = ko.observable(data.Edited);

};

bn.Vendor = function (data) {
    this.VendorID = ko.observable(data.VendorID);
    this.Vendnum = ko.observable(data.Vendnum);
    this.Company = ko.observable(data.Company).extend({ required: true });
    this.DBA = ko.observable(data.DBA);
    this.Address1 = ko.observable(data.Address1).extend({ required: true });
    this.Address2 = ko.observable(data.Address2);
    this.City = ko.observable(data.City).extend({ required: true });
    this.State = ko.observable(data.State).extend({ required: true });
    this.Zip = ko.observable(data.Zip).extend({ required: true });
    this.Country = ko.observable(data.Country);
    this.Province = ko.observable(data.Province);
    this.Phone = ko.observable(data.Phone).extend({ required: true });
    this.PhoneExt = ko.observable(data.PhoneExt);
    this.Fax = ko.observable(data.Fax);
    this.Mobile = ko.observable(data.Mobile);
    this.Emergency = ko.observable(data.Emergency);
    this.Contact = ko.observable(data.Contact);
    this.Email = ko.observable(data.Email);
    this.AutoEmail = ko.observable(data.AutoEmail);
    this.Comment = ko.observable(data.Comment);
    this.VendorType = ko.observable(data.VendorType);
    this.GLnum = ko.observable(data.GLnum);
    this.TaxID = ko.observable(data.TaxID).extend({ required: true });
    this.NetDays = ko.observable(data.NetDays);
    this.CheckTax1099 = ko.observable(data.CheckTax1099);
    this.PVA = ko.observable(data.PVA);
    this.SignedContract = ko.observable(data.SignedContract);
    this.CreditCardHolder = ko.observable(data.CreditCardHolder);
    this.W9 = ko.observable(data.W9);
    this.PaymentTerms = ko.observable(data.PaymentTerms);
    this.CashDiscount = ko.observable(data.CashDiscount);
    this.PricingYear = ko.observable(data.PricingYear);
    this.Overallrating = ko.observable(data.Overallrating);
    this.WebAccessUser = ko.observable(data.WebAccessUser);
    this.WebAccessPwd = ko.observable(data.WebAccessPwd);
    this.InputBy = ko.observable(data.InputBy);
    if (data.InputDate) {
        var newInputDate = moment(data.InputDate).format("MM/DD/YYYY");
        this.InputDate = ko.observable(newInputDate);
    }
    else {
        this.InputDate = ko.observable();
    }
    //this.InputDate = ko.observable(data.InputDate);
    this.LastModifiedBy = ko.observable(data.LastModifiedBy);
    if (data.LastModifiedDate) {
        var newDate = moment(data.LastModifiedDate).format("MM/DD/YYYY");
        this.LastModifiedDate = ko.observable(newDate);
    }
    else {
        this.LastModifiedDate = ko.observable();
    }
    //this.LastModifiedDate = ko.observable(data.LastModifiedDate);
    this.GradeID = ko.observable(data.GradeID);

    // Vendor Remit To
    this.VendorRemitToes = ko.observableArray(data.VendorRemitToes);

    // Vendor Insurances


    //this.VendorNotes = ko.observableArray(data.VendorNotes);
};
//#endregion


bn.vmVendorList = (function ($, bn, undefined) {


    this.infuser.defaults.templateSuffix = ".html";
    this.infuser.defaults.templateUrl = "/Templates/VendorListing";

    var
        self = this,
        vendors = ko.observableArray([]),
        countries = ["USA", "Canada"],
        states = ko.observableArray(["AL", "CA", "NY", "WI", "MT", "MD"]),  //Eventually they will come from DB
        selectedState = ko.observable(""),

        //-----
        pageSize = ko.observable(10),
        totalPages = ko.observable(0),
        currentPage = ko.observable(1),
        totalRows = ko.observable(0),
        //-----
        applyMask = function () {
            $("#vendorphone").mask("(999) 999-9999");
            $("#vendorfax").mask("(999) 999-9999");
        },
        selectedVendor = ko.observable(),

        selectVendor = function (p) {
            //debugger;
            selectedVendor(p);
            //set Selected Flag
            isSelected(true);
        },

        editingVendor = ko.observable(),

        createVendor = function (vm, v) {
            inEditMode(true);
            //make blank skeleton and pass it over
            var remiTo = [new bn.RemitTo({})];
            var vendor = new bn.Vendor({});
            vendor.VendorRemitToes = remiTo;

            //now fix selection
            selectedVendor(vendor);
            fixTabNavigation();

            ko.editable(selectedVendor());
            editingVendor(vendor);
            editingVendor().beginEdit();
            applyMask();
        },

        //Command for the Edit Button... Set VM to 'Editing' mode...
        editVendor = function (vm, v) {

            inEditMode(true);   //Set the editMode flag
            fixTabNavigation();    //Fix tab States

            //--Make the row Editable with rollback option
            //ko.editable(selectedVendor());
            editingVendor(selectedVendor());
            ko.editable(editingVendor());
            editingVendor().beginEdit();
            //--
            applyMask();
        },

        cancelEdit = function () {
            editingVendor().rollback();
            //next call is not required if we simply close out the form...
            //editingVendor().beginEdit();
            inEditMode(false);
            fixTabNavigation(); //Reset Tab States
        },


        saveDetails = function () {
            //var data = ko.toJSON(
            alert(editingVendor().errors().length);
            editingVendor().commit();
            //bn.ajaxService.updateVendors(editingVendor, onSuccessSaveDetails, onErrorSaveDetails);

        },
        //callback methods for 'saveDetails'
        onSuccessSaveDetails = function (result) {
            //alert('Inside onSuccessSaveDetails');
            toastr.success("Record has been updated successfully", "Success");
            //Reload
            loadVendors();
            //--Reset
            selectedVendor(undefined);
            editingVendor(undefined);
            isSelected(false);
            inEditMode(false);
            //--
            fixTabNavigation();


        },
        onErrorSaveDetails = function (error) {
            //alert('Inside onErrorSaveDetails');
            toastr.error("An unexpected error occurred. Please try again", "Error");
        },

        //saveEdit = function () {
        //    editingVendor().commit();
        //    selectedVendor(undefined);
        //    editingVendor(undefined);
        //    isSelected(false);
        //    $("#mainModal03").modal("hide");
        //    inEditMode(false);
        //},

        inEditMode = ko.observable(false),

        isSelected = ko.observable(false),  //this is used to Enable/Disable the Edit Button.

        showDetails = function (item, e) {  // The ShowDetails Tab click handler
            if (selectedVendor()) {
                return true;
            }
            else if (vendors().length > 0) {
                selectedVendor(vendors()[0]);   //mark the 1st one as selected
            }
            return true;
        },

        onSuccessLoadVendor = function (result) {
            //debugger;
            totalPages(Math.ceil(result.VirtualRowCount / pageSize()));
            console.log('--' + totalPages());
            //--
            //Set Total Row Count
            totalRows(result.VirtualRowCount);
            var temp = [];
            //var mappedVendors = $.map(result.Data, function (item) { return new bn.Vendor(item) });
            var mappedVendors = $.map(result.Data, function (data) {

                //Create the RemitTo
                var RemitTo = ko.utils.arrayMap(data.VendorRemitToes, function (RemitTo) {
                    return new bn.RemitTo(RemitTo);
                });
                //build the Insurance ... there will always be 3 [GL, WC, Auto]
                //----

                //----
                data.VendorRemitToes = RemitTo;
                //Now create the Parent vendor
                return new bn.Vendor(data);
            });
            //Load up in one go
            vendors([]);
            return vendors.push.apply(vendors, mappedVendors);
        },

        onErrorLoadVendor = function (err) {
            toastr.error("An unexpected error occurred. Please try again", "Error");
        },

        loadVendors = function () {
            //$.getJSON("/VendorListing/getallvendors", { pageSize: pageSize(), currentPage: currentPage() }, function (result) {
            //    onSuccessLoadVendor(result);
            //});
            //get the SEARCH string...
            var vendorNum = $('#searchVendNum').val();
            //--
            bn.ajaxService.getVendors({ pageSize: pageSize(), currentPage: currentPage(), vendorNum: vendorNum }, onSuccessLoadVendor, onErrorLoadVendor);
        },

        //#region Private Members
        fixTabNavigation = function () {
            if (inEditMode()) {
                $('#tabstwo').tabs("select", 1);
                $('#tabstwo').tabs("option", "disabled", [0, 4, 5, 6, 7, 8, 9, 10, 11, 12]);
            }
            else {
                $('#tabstwo').tabs("option", "disabled", []);
                $('#tabstwo').tabs("select", 0);
            }
        };
    //#endregion

    return {
        states: states,
        countries: countries,
        vendors: vendors,
        inEditMode: inEditMode,
        selectVendor: selectVendor,
        selectedVendor: selectedVendor,
        isSelected: isSelected,
        editVendor: editVendor,
        editingVendor: editingVendor,
        cancelEdit: cancelEdit,
        //--pager options
        pageSize: pageSize,
        totalPages: totalPages,
        currentPage: currentPage,
        totalRows: totalRows,
        //--methods
        loadVendors: loadVendors,
        saveDetails: saveDetails,
        showDetails: showDetails,
        createVendor: createVendor
        //init: init
    };

})(jQuery, bn);

//var vm = {};
$(function () {

    //$('#tabstwo').tabs(),

    //$("#tabstwo").bind("tabsselect", function (e, tab) {
    //    if (tab.index > 0) {
    //        bn.vmVendorList.showDetails(tab, e);
    //    }
    //});

    //Set up notification when selecttion changes
    bn.vmVendorList.selectedVendor.subscribe(function (data) {
        if (data) {
            var vendorID = ko.utils.unwrapObservable(data.VendorID);
            var vendorNum = ko.utils.unwrapObservable(data.Vendnum);
            //send notification
            amplify.publish("VendorSelectionChanged", vendorID, vendorNum);
        }
    });

    amplify.subscribe("EditVendor", bn.vmVendorList.editVendor);

    //bn.vmVendorList.init();



});


