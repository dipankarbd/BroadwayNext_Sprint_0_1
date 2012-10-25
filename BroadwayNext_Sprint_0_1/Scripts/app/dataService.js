var bn = bn || {};
    //bn.ds = bd.ds || {};

    

(function ($, amplify, bn, undefined) {

    var serviceBaseVendors = "/VendorListing/",
        serviceMock = "http://localhost:12280/VendorRPC/GetVendors";

    bn.ajaxService = (function (bn) {

        //Load Vendors from Server
        var
            ajaxGetVendors = function (jsonIn, callback, onError) {
            //////Console.log("inside GetAjaxVendor");
            $.ajax({
                url: serviceBaseVendors + "GetAllVendors",
                type: "GET",
                data: jsonIn,
                datatType: "json",
                contentType: "application/json",
                success: function (vendors) {
                    callback(vendors);
                },
                error: function (xhr) {
                    var err = "Error";
                    //alert(err);
                    onError(xhr);
                }
            });
            },
            ajaxPostVendors = function (jsonIn, callback, onError) {
                $.ajax({
                    url: serviceBaseVendors + "Save",
                    type: "POST",
                    data: ko.toJSON(jsonIn),
                    datatType: "json",
                    contentType: "application/json",
                    success: function (success) {
                        callback(success);
                    },
                    error: function (xhr) {
                        var err = "Error";
                        //alert(err);
                        onError(xhr);
                    }
                });
            };
        return {
            getVendors: ajaxGetVendors,
            updateVendors: ajaxPostVendors
        };



    })(bn);


})(jQuery, amplify, bn);

