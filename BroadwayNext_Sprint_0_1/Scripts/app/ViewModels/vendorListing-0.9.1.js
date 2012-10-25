/*
// Version : 0.9.1 -- EDITABLE SCOPE [DONE]

Goal ==> Vendor Insurance Update/Insert 

Result: ==>  Done

Next Version ==> 


*/

var bn = bn || {};


//#region "MODEL"
bn.Insurance = function (data) {
    this.VendorInsuranceID = ko.observable(data.VendorInsuranceID);
    this.VendorID = ko.observable(data.VendorID);
    this.InsuranceType = ko.observable(data.InsuranceTypeID);       // Actual ID of the InsuranceType
    this.InsuranceTypeName = ko.observable(data.InsuranceTypeName); // General, Auto etc.
    this.InsuranceName = ko.observable(data.InsuranceName).extend({ editable: { scope: 'Insurance' } }); //.extend({required: true});         // Name of the Insurance Company
    this.Policynum = ko.observable(data.Policynum).extend({ editable: { scope: 'Insurance' } });
    this.ExpiryDate = ko.observable(data.ExpiryDate).extend({ editable: { scope: 'Insurance' } });
    this.AdditionalInsured = ko.observable(data.AdditionalInsured).extend({ editable: { scope: 'Insurance' } });
    this.Not_onFile = ko.observable(data.Not_onFile).extend({ editable: { scope: 'Insurance' } });
    this.InsuranceNotRequired = ko.observable(data.InsuranceNotRequired).extend({ editable: { scope: 'Insurance' } });
    this.NotRequiredReason = ko.observable(data.NotRequiredReason);
};

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
    this.State = ko.observable(data.State); //.extend({ required: true });  //disable until State Table
    this.Zip = ko.observable(data.Zip).extend({ required: true });
    this.Country = ko.observable(data.Country);
    this.Province = ko.observable(data.Province);
    this.Phone = ko.observable(data.Phone); //.extend({ required: true });
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
    this.TaxID = ko.observable(data.TaxID); //.extend({ required: true });  //What about SSN?
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
    this.VendorInsurances = ko.observableArray(data.VendorInsurances);

    //this.VendorNotes = ko.observableArray(data.VendorNotes);
};
//#endregion


bn.vmVendorList = (function ($, bn, undefined) {


    this.infuser.defaults.templateSuffix = ".html";
    this.infuser.defaults.templateUrl = "/Templates/VendorListing";

    var
        self = this,
        vendors = ko.observableArray([]),

        //-- Flags
        modelIsValid = ko.observable(true),     //This flag is set from the ValidateObservable utility method
        insHasChanged = ko.observable(false),
        //---
        countries = ["USA", "Canada"],
        insNotReqReasons = ["Reason 1", "Reason 2", "Reason 3", "Reason 4", "Reason 5"]
        states = ko.observableArray(["AL", "CA", "NY", "WI", "MT", "MD"]),  //Eventually they will come from DB
        selectedState = ko.observable(""),
        _vendorInsTypes = [],
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
            isSelected(true);   //set Selected Flag
        },

        editingVendor = ko.observable(),

        createVendor = function (vm, v) {
            var vendor = new bn.Vendor({});
            //make blank skeleton and pass it over
            var remitTo = [new bn.RemitTo({})];
            vendor.VendorRemitToes(remitTo);    //Set RemitTo
            //make mock Insurances
            var insurance = [];
            if (_vendorInsTypes.length) {
                insurance = buildInsurances(_vendorInsTypes);
                vendor.VendorInsurances(insurance); //Set Insurance
                //now fix selection
                selectedVendor(vendor);
                //start editing
                editVendor();
            }
            else {
                //fetch Insurance Types ... this happens when someone hits New before Search
                $.when($.getJSON("/VendorListing/GetInsuranceTypes"))
                    .then(function (result) {
                        if (result) {
                            //Console.log('inside resolve');
                            _vendorInsTypes.push.apply(_vendorInsTypes, result);
                            insurance = buildInsurances(_vendorInsTypes);
                        }
                        vendor.VendorInsurances(insurance); //Set Insurance
                        //now fix selection
                        selectedVendor(vendor);
                        //start editing
                        editVendor();
                    });
                    //.done(function () {
                        
                    //});
                //if (_vendorInsTypes.length)
                //    insurance = buildInsurances(_vendorInsTypes);
            }
            
        },

        editVendor = function () {     //Command for the Edit Button... Set VM to 'Editing' mode...(vm, v)

            inEditMode(true);   //Set the editMode flag
            fixTabNavigation();    //Fix tab States

            //--Make the row Editable with rollback option
            editingVendor(selectedVendor());
            //** -- 
            ko.editable.beginEdit('Insurance');
            //** /--
            ko.editable(editingVendor());
            editingVendor().beginEdit();
            //--
            applyMask();
        },

        cancelEdit = function () {

            //--
            var hasChange = ko.editable.hasChanges('Insurance');
            //--
            editingVendor().rollback();
            //next call is not required if we simply close out the form...
            //editingVendor().beginEdit();
            inEditMode(false);
            modelIsValid(true); //Reset modelIsValid in case its been 'false'
            editingVendor(undefined);
            fixTabNavigation(); //Reset Tab States
        },

        saveDetailsCmd = ko.asyncCommand({
            execute: function (complete) {
                //prepare Ins before send
                var hasInsChanged = ko.editable.hasChanges('Insurance');    // check if Insurance has changed or not
                if (hasInsChanged) {
                    //send the ones with CompanyName and Policy [bare minimum checking...]
                    var cleanIns = clearInsurances(editingVendor().VendorInsurances());
                    //Console.log(cleanIns.length);
                    editingVendor().VendorInsurances(cleanIns);
                }
                else {
                    //remove all insurances
                    editingVendor().VendorInsurances([]);
                }
                editingVendor().commit();
                //POST to Server after fixing everything...
                bn.ajaxService.updateVendors(editingVendor, onSuccessSaveDetails, onErrorSaveDetails);
                complete();
            },
            canExecute: function (isExecuting) {
                return !isExecuting && modelIsValid();
            }
        }),
        
        onSuccessSaveDetails = function (result) {      //callback methods for 'saveDetails'
            //alert('Inside onSuccessSaveDetails');
            toastr.success("Record has been updated successfully", "Success");
            reloadAndReset();
        },

        onErrorSaveDetails = function (error) {
            //alert('Inside onErrorSaveDetails');
            toastr.error("An unexpected error occurred. Please try again", "Error");
            reloadAndReset();
        },

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
            //Console.log('--' + totalPages());
            //--
            //Set Total Row Count
            totalRows(result.VirtualRowCount);
            var temp = [];
            var mappedVendors = $.map(result.Data, function (data) {
                ////Create the RemitTo
                var RemitTo = [{}];
                if (data.VendorRemitToes.length) {
                    RemitTo = ko.utils.arrayMap(data.VendorRemitToes, function (RemitTo) {
                        return new bn.RemitTo(RemitTo);
                    });
                }
                else {
                    //Add blank
                    RemitTo = [new bn.RemitTo({})];
                    //Console.log("RemitTo length : " + RemitTo.length);
                }
                //build the Insurance ... there will always be 3 [GL, WC, Auto]
                var insTemp = [];
                insTemp = buildInsurances(result.InsuranceTypes, data);
                data.VendorInsurances = insTemp;
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

        loadInsuranceTypes = function () {
            $.getJSON("/VendorListing/GetInsuranceTypes", function (result) {
                if (result) {
                    //Console.log('got result back');
                    return _vendorInsTypes.push.apply(_vendorInsTypes, result);
                }
            });
        },

        loadVendors = function () {
            //get the SEARCH string...
            var vendorNum = $('#searchVendNum').val();
            bn.ajaxService.getVendors({ pageSize: pageSize(), currentPage: currentPage(), vendorNum: vendorNum }, onSuccessLoadVendor, onErrorLoadVendor);
        },
        
        deleteVendor = function (data) {
            if (confirm('Are you sure you want to delete this vendor? All other information related to this Vendor will be deleted as well.')) {
                console.log('inside DeleteVendor');
                $.ajax("/vendorlisting/DeleteVendorAll", {
                    data: ko.toJSON({ vendorID: selectedVendor().VendorID()}),
                    type: "post", contentType: "application/json",
                    success: function (result) {
                        if (result.Success) {
                            toastr.success("Vendor information deleted successfully", "Success");
                        }
                        else {
                            toastr.error("An unexpected error occurred. Please try again", "Error");
                        }
                        reloadAndReset();
                    }
                });
            }
        },

    //#region Utlity methods
    
        buildInsurances = function (InsuranceTypes, data) {
            var result = [];
            ko.utils.arrayForEach(InsuranceTypes, function (insType) {
                //Cache insTypes internally for later use
                if (_vendorInsTypes.length < InsuranceTypes.length)
                    _vendorInsTypes.push(insType);
                //Check if we have it already or not
                var vendorIns;
                if (data) {
                    vendorIns = ko.utils.arrayFirst(data.VendorInsurances, function (vndIns) {
                        return (vndIns.InsuranceType === insType.InsuranceTypeID);
                    });
                }
                if (vendorIns) {
                    ////Console.log('found a match');
                    vendorIns.InsuranceTypeName = insType.InsuranceType;
                    vendorIns.InsuranceTypeID = insType.InsuranceTypeID;    //hack due to inconsistency of names in 2 tables
                    var ins = new bn.Insurance(vendorIns);
                    result.push(ins);
                }
                else {
                    //didn't find any match, so build an empty one and add
                    var emptyIns = createEmptyInsurance(insType);
                    result.push(emptyIns);
                }
            });
            return result;
        },

        createEmptyInsurance = function (insType) {
            var insData = {};
            insData.InsuranceTypeID = insType.InsuranceTypeID;
            insData.InsuranceTypeName = insType.InsuranceType;
            var emptyIns = new bn.Insurance(insData);
            return emptyIns;
        },

        clearInsurances = function (insurances) {       //Only get the ones with valid Company and PolicyNum
            return ko.utils.arrayFilter(insurances, function (ins) {
                //Console.log("Name: " + ins.InsuranceName());
                //Console.log("Policy: " + ins.Policynum());
                return (ins.InsuranceName() && ins.Policynum());
            });
        },

        reloadAndReset = function () {
            //Reload
            loadVendors();
            //--Reset
            selectedVendor(undefined);
            editingVendor(undefined);
            isSelected(false);
            inEditMode(false);
            modelIsValid(true);
            //--
            fixTabNavigation();
        },

        fixTabNavigation = function () {
            if (inEditMode()) {
                $('#tabstwo li:eq(1) a').tab('show');   // Set the Details tab as 'Active'
                $('#tabstwo li a').filter(function (index) {
                    return (index == 0) || (index > 3);
                })
                .removeAttr('data-toggle');
            }
            else {
                $('#tabstwo li a').attr('data-toggle', 'tab');
                $('#tabstwo li:eq(0) a').tab('show');     // Reset the Listing tab to be 'Active' again

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
        modelIsValid: modelIsValid,
        //--pager options
        pageSize: pageSize,
        totalPages: totalPages,
        currentPage: currentPage,
        totalRows: totalRows,
        //--methods
        loadVendors: loadVendors,
        saveDetailsCmd: saveDetailsCmd,
        showDetails: showDetails,
        createVendor: createVendor
        //init: init
    };

})(jQuery, bn);

//var vm = {};
$(function () {

    $('#tabstwo a').click(function (e) {
        bn.vmVendorList.showDetails(e);
    })

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

});


