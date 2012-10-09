(function ($, undefined) {
    ko.bindingHandlers['modal'] = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            var allBindings = allBindingsAccessor();
            var $element = $(element);
            $element.addClass('hide modal');

            if (allBindings.modalOptions) {
                if (allBindings.modalOptions.beforeClose) {
                    $element.on('hide', function () {
                        return allBindings.modalOptions.beforeClose();
                    });
                }
            }

            //return ko.bindingHandlers['with'].init.apply(this, arguments);
        },
        update: function (element, valueAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());

            //var returnValue = ko.bindingHandlers['with'].update.apply(this, arguments);

            if (value) {
                $(element).modal('show');
            } else {
                $(element).modal('hide');
            }

            //return returnValue;
        }
    };

    ko.bindingHandlers.readOnly = {
        update: function (element, valueAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            if (value) {
                element.setAttribute("readOnly", true);
            } else {
                element.removeAttribute("readOnly");
            }
        }
    };

    ko.bindingHandlers.date = {
        //init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        //    var jsonDate = ko.utils.unwrapObservable(valueAccessor());
        //    var value = moment(jsonDate).format("MM-DD-YYYY");
        //    element.innerHTML = value;
        //},
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            //alert(ko.utils.unwrapObservable(valueAccessor));
            var jsonDate = ko.utils.unwrapObservable(valueAccessor());
            if (jsonDate) {
                var regularDate = moment(jsonDate).format("MM/DD/YYYY");
                $(element).val(regularDate);
            }
        }

    };

    ko.bindingHandlers.date1 = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var jsonDate = valueAccessor();
            var value = new Date(parseInt(jsonDate.substr(6),10));
            var ret = value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
            element.innerHTML = ret;
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {

        }
    };

    ko.bindingHandlers.gridpager = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var value = valueAccessor(), allBindings = allBindingsAccessor();

            //allBindings.datasource();

            $(element).addClass("pagination");
            $(element).append("<ul></ul>");

            //handle disposal
            ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                $(element).empty();
            });
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var value = valueAccessor(), allBindings = allBindingsAccessor();
            var valueUnwrapped = ko.utils.unwrapObservable(value);

            var totalPages = valueUnwrapped;
            var pageSize = ko.utils.unwrapObservable(allBindings.pagesize) || 10;
            var curentPage = ko.utils.unwrapObservable(allBindings.currentpage) || 1;

            console.log('total pages:' + totalPages + ', currentPage:' + curentPage + ', pageSize:' + pageSize);
            var pagerItemCount = 5;
            var offset = Math.ceil(pagerItemCount / 2) - 1;
            var start = curentPage - offset;
            if (start < 1) start = 1;

            var end = start + pagerItemCount - 1;
            if (end > totalPages) end = totalPages;


            var i = 0;

            $(element).find("ul").empty();
            if (curentPage > 1) {
                $(element).find("ul").append('<li><a href="#">&lt;&lt;</a></li>');
                $(element).find("ul").append('<li><a href="#">&lt;</a></li>');

                if (curentPage - pagerItemCount > 0) {
                    $(element).find("ul").append('<li><a class="left" href="#">...</a></li>');
                }
            }
            for (i = start; i <= end; i++) {
                if (i === curentPage) {
                    $(element).find("ul").append('<li  class="active"><a href="#">' + i + '</a></li>');
                } else {
                    $(element).find("ul").append('<li><a href="#">' + i + '</a></li>');
                }
            }
            if (curentPage < totalPages) {
                if (curentPage + pagerItemCount < totalPages) {
                    $(element).find("ul").append('<li><a class="right" href="#">...</a></li>');
                }
                $(element).find("ul").append('<li><a href="#">&gt;</a></li>');
                $(element).find("ul").append('<li><a href="#">&gt;&gt;</a></li>');
            }
            $(element).find("ul li a").click(function () {
                var selectedPage = $(this).text();
                if (selectedPage === "<") {
                    curentPage = curentPage - 1;
                    if (curentPage < 1) curentPage = 1;
                    allBindings.currentpage(curentPage);
                }
                else if (selectedPage === ">") {
                    curentPage = curentPage + 1;
                    if (curentPage > totalPages) curentPage = totalPages;
                    allBindings.currentpage(curentPage);
                }
                else if (selectedPage === "<<") {
                    curentPage = 1;
                    allBindings.currentpage(curentPage);
                }
                else if (selectedPage === ">>") {
                    curentPage = totalPages;
                    allBindings.currentpage(curentPage);
                }
                else if (selectedPage === "...") {
                    if ($(this).attr('class') === 'left') {
                        curentPage = curentPage - pagerItemCount;
                        if (curentPage < 1) curentPage = 1;
                    }
                    else if ($(this).attr('class') === 'right') {
                        curentPage = curentPage + pagerItemCount;
                        if (curentPage > totalPages) curentPage = totalPages;
                    }
                    allBindings.currentpage(curentPage);
                }
                else {
                    allBindings.currentpage(parseInt(selectedPage,10));
                }
                allBindings.datasource();
            });

        }
    };


})(jQuery);