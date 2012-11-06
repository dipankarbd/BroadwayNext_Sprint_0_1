/*
// Version : 0.9.1.0 -- BACKUP for 0.9.1

Goal ==> 

Result: ==> 

Next Version ==> 


*/

var bn = bn || {};


/* Email Reply --
InsuranceName : Name of the Insurnace company
Insurance type is : GUID
Insurance TypeName : General, Auto or Workman’s
Policy number : I guess I did not see that coming. Lets make that nvarchar(50)
*/
//#region "MODEL"
bn.Insurance = function (data) {
    this.VendorInsuranceID = ko.observable(data.VendorInsuranceID);
    this.VendorID = ko.observable(data.VendorID);
    this.InsuranceType = ko.observable(data.InsuranceTypeID);         // Actual ID of the InsuranceType
    this.InsuranceTypeName = ko.observable(data.InsuranceTypeName); // General, Auto etc.
    this.InsuranceName = ko.observable(data.InsuranceName).extend({editable: { scope: 'Insurance' }}); //.extend({required: true});         // Name of the Insurance Company
    this.Policynum = ko.observable(data.Policynum).extend({ editable: { scope: 'Insurance' } });
    this.ExpiryDate = ko.observable(data.ExpiryDate).extend({ editable: { scope: 'Insurance' } });
    this.AdditionalInsured = ko.observable(data.AdditionalInsured).extend({ editable: { scope: 'Insurance' } });
    this.NOF = ko.observable(data.Not_onFile).extend({ editable: { scope: 'Insurance' } });

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
    this.Company = ko.observable(data.Company).extend({required : true});
    this.DBA = ko.observable(data.DBA);
    this.Address1 = ko.observable(data.Address1).extend({required : true});
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
        modelIsValid = ko.observable(true),
        insHasChanged = ko.observable(false),
        //------
        countries = ["USA", "Canada"],
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
            //inEditMode(true);
            //make blank skeleton and pass it over
            //RemitTo = [new bn.RemitTo({})];
            var remitTo = new bn.RemitTo({});
            //make mock Insurances
            var insurance = [];
            if (_vendorInsTypes.length) {
                insurance = buildInsurances(_vendorInsTypes);
                //create mock ins
                //ko.utils.arrayForEach(_vendorInsTypes, function (insType) {
                //    var emptyIns = createEmptyInsurance(insType);
                //    insurance.push(emptyIns);
                //});
            }
            else {
                //fetch Insurance Types ...
            }
            var vendor = new bn.Vendor({});
            vendor.VendorRemitToes(remitTo);
            vendor.VendorInsurances(insurance);
            //now fix selection
            selectedVendor(vendor);
            //start editing
            editVendor();
        },

        editVendor = function () {     //Command for the Edit Button... Set VM to 'Editing' mode...(vm, v)

            inEditMode(true);   //Set the editMode flag
            fixTabNavigation();    //Fix tab States

            //--Make the row Editable with rollback option
            //ko.editable(selectedVendor());
            editingVendor(selectedVendor());
            //** -- 
            ko.editable.beginEdit('Insurance');
            //** /--
            ko.editable(editingVendor());
            editingVendor().beginEdit();
            //--
            applyMask();
        },
        
        /* -- OLD editVendor[works]
        editVendor = function (vm, v) {     //Command for the Edit Button... Set VM to 'Editing' mode...

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
        */
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
                if(hasInsChanged){
                    //send the ones with CompanyName and Policy [bare minimum checking...]
                    //var cleanIns = [];
                    //var cleanIns = clearInsurances(ko.utils.unwrapObservable(editingVendor().VendorInsurances()));
                    var cleanIns = clearInsurances(editingVendor().VendorInsurances());

                    //var cleanIns = ko.utils.arrayFilter(editingVendor().VendorInsurances(), function (ins) {
                    //    console.log("Name: " + ins.InsuranceName());
                    //    console.log("Policy: " + ins.Policynum());
                    //    return ( ins.InsuranceName() && ins.Policynum() );
                    //});
                    console.log(cleanIns.length);
                    editingVendor().VendorInsurances(cleanIns);
                }
                else {
                    //remove all insurances
                    editingVendor().VendorInsurances([]);
                }
                
                
                
                //if (editingVendor().VendorID()) {                       //If VendorID -- Existing
                //    if (hasInsChanged) {
                //        console.log("Insurance has changed");
                //    }
                //    else {
                //        //remove all insurances
                //        editingVendor().VendorInsurances([]);
                //    }
                //}
                //else {                                              //Else - New
                //    if(
                //}
                //--
                editingVendor().commit();
                //Call this after fixing everything...
                bn.ajaxService.updateVendors(editingVendor, onSuccessSaveDetails, onErrorSaveDetails);
                complete();
            },
            canExecute: function (isExecuting) {
                return !isExecuting && modelIsValid();
            }
        }),
        //-- Old saveDetailsCmd [works]
        //saveDetailsCmd = ko.asyncCommand({
        //    execute: function (complete) {
        //        editingVendor().commit();
        //        bn.ajaxService.updateVendors(editingVendor, onSuccessSaveDetails, onErrorSaveDetails);
        //        complete();
        //    },
        //    canExecute: function (isExecuting) {
        //        return !isExecuting && modelIsValid();
        //    }
        //}),
      
        onSuccessSaveDetails = function (result) {      //callback methods for 'saveDetails'
            //alert('Inside onSuccessSaveDetails');
            toastr.success("Record has been updated successfully", "Success");
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
                    console.log("RemitTo length : " + RemitTo.length);
                }

                //--------------    OLD
                //var RemitTo = ko.utils.arrayMap(data.VendorRemitToes, function (RemitTo) {
                //    //console.log('inside RemitTo');
                //    if (RemitTo)
                //        return new bn.RemitTo(RemitTo);
                //    else
                //        return new bn.RemitTo({});
                //});
                //--------------- /OLD
                //build the Insurance ... there will always be 3 [GL, WC, Auto]
                //--- NEW ----------
                var insTemp = [];
                
                insTemp = buildInsurances(result.InsuranceTypes, data);
                //Now do a sort so we can have the strage ordering in the array

                data.VendorInsurances = insTemp;

                //--- /NEW ----------
                //var cleanIns = clearInsurances(insTemp);
                //console.log("After call -> Length -> " + cleanIns.length);

                //---- ABONDONED ----------------------------
                //var Insurance = ko.utils.arrayMap(data.VendorInsurances, function (Insurance) {
                //    var insTypeName = Insurance.VendorInsuranceType.InsuranceType;
                //    Insurance.InsuranceTypeName = insTypeName;
                //    return new bn.Insurance(Insurance);
                //});
                //---- /ABONDONED   -----------------------------

                data.VendorRemitToes = RemitTo;
                //data.VendorInsurances = Insurance;
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
        
        


        buildInsurances = function (InsuranceTypes, data) {
            var result = [];
            ko.utils.arrayForEach(InsuranceTypes, function (insType) {
                //Cache insTypes internally for later use
                if(_vendorInsTypes.length < InsuranceTypes.length)
                    _vendorInsTypes.push(insType);
                //Check if we have it already or not
                var vendorIns;
                if (data) {
                    vendorIns = ko.utils.arrayFirst(data.VendorInsurances, function (vndIns) {
                        return (vndIns.InsuranceType === insType.InsuranceTypeID);
                    });

                }
                if (vendorIns) {
                    //console.log('found a match');
                    vendorIns.InsuranceTypeName = insType.InsuranceType;
                    vendorIns.InsuranceTypeID = insType.InsuranceTypeID;    //hack due to inconsistency of names in 2 tables
                    var ins = new bn.Insurance(vendorIns);
                    result.push(ins);
                }
                else {
                    //didn't find any match, so build an empty one and add
                    //var insData = {};
                    //insData.InsuranceTypeID = insType.InsuranceTypeID;
                    //insData.InsuranceTypeName = insType.InsuranceType;
                    //emptyIns = new bn.Insurance(insData);
                    var emptyIns = createEmptyInsurance(insType);
                    result.push(emptyIns);
                }
            });
           
            //console.log("Length: " + result.length);   //every Vendor should have same number of Insurance by now.
            //ko.utils.arrayForEach(result, function (ins) {
            //    console.log("Name: " + ins.InsuranceName());
            //});
            //console.log("------------------------------------------");
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
                console.log("Name: " + ins.InsuranceName());
                console.log("Policy: " + ins.Policynum());
                return ( ins.InsuranceName() && ins.Policynum() );
            });
        },

        //#region Private Members
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


            //if (inEditMode()) {
            //    $('#tabstwo').tabs("select", 1);
            //    $('#tabstwo').tabs("option", "disabled", [0, 4, 5, 6, 7, 8, 9, 10, 11, 12]);
            //}
            //else {
            //    $('#tabstwo').tabs("option", "disabled", []);
            //    $('#tabstwo').tabs("select", 0);
            //}
        };
        //#endregion

        return {
            states: states,
            countries : countries,
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
            pageSize : pageSize,
            totalPages : totalPages,
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

    //$('#tabstwo').tabs(),

    //$("#tabstwo").bind("tabsselect", function (e, tab) {
    //    if (tab.index > 0) {
    //        bn.vmVendorList.showDetails(tab, e);
    //    }
    //});

    $('#tabstwo a').click(function (e) {
        bn.vmVendorList.showDetails(e);
        //e.preventDefault();
        //$(this).tab('show');
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

    //bn.vmVendorList.init();

    

});


