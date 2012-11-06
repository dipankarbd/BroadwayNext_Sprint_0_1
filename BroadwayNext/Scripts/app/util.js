var bn = bn || {};




bn.config = (function () {
    var
        self = this,
        phoneMask = '(999) 999-9999';

    return {
        phoneMask: phoneMask
    }

}())



bn.utils = (function () {
    var
        self = this,
        validateObservable = function (itemToValidte, viewModel, data, event) {     //data == the editingEntity()
            //console.log("inside validateObservable -- For : " + itemToValidte);
            for (var prop in data) {
                if (prop === itemToValidte) {
                    var theObservable = data[prop];
                    //theObservable.valueHasMutated();
                    ko.validation.validateObservable(theObservable);
                    if (theObservable.error) {
                        viewModel.modelIsValid(false);
                    }
                    else {
                        if (!(viewModel.modelIsValid())) {
                            var errors = ko.utils.unwrapObservable(ko.validation.group(data));
                            viewModel.modelIsValid(errors.length < 1);
                        }
                    }
                }
            }
            return true;
        };
    return {
        validateObservable: validateObservable
    };

}())
