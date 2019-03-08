var media = media || {};

//Service class use for centralizing access to make ajax requests.
media.DataService = function () {
    function defaultErrorHandler(model) {
        if (model === undefined || model.Messages === undefined) {
            alert("An unhandle error occured!!"); return;
        }
    }
    function requestHandler(type, url, data, contentType, processData, onSuccessCallBack, onErrorCallBack) {
        if (onErrorCallBack === null || onErrorCallBack === undefined) {
            onErrorCallBack = defaultErrorHandler;
        }

        $.ajax({
            type: type,
            data: data,
            url: url,
            contentType: contentType,
            processData: processData,
            dataType: "json",
            cache: false,
            headers: {
                // 'VerificationToken': getToken()
            },
            statusCode: {
                200: function (model) {
                    onSuccessCallBack(model);
                },
                400: function (model) {
                    if (model === null) {
                        alert("An Error occured!");
                        return;
                    }
                    onErrorCallBack(model.responseJSON);
                }
            },
            error: function (model) {
                if (model.status !== 401 && model.status !== 400) {
                    onErrorCallBack(model.responseJSON);
                }
            }
        });
    }

    return {
        post: function (url, data, onSuccessCallBack, onErrorCallBack) {
            requestHandler("POST", url, data === null ? null : JSON.stringify(data), "application/json; charset=UTF-8", true, onSuccessCallBack, onErrorCallBack);
        },
        get: function (url, onSuccessCallBack, onErrorCallBack) {
            requestHandler("GET", url, null, "application/json; charset=UTF-8", true, onSuccessCallBack, onErrorCallBack);
        }
    };
};

//Contains functionality to access business services provided by web api.
media.PublicationService = function () {
    var self = this;
    self.service = new media.DataService();
    self.ractive = null;
    self.templateName = null;
    self.elementName = null;
    self.tableName = null;
    self.dataTable = [];

    //Initializes the ractive object and renders templates
    self.initView = function (element, template, data) {
        self.ractive = new Ractive({
            el: "#" + element,
            template: "#" + template,
            data: {
                dataModel: data,
                isLoading: false
            }
        });
        self.ractive.on({
            ondownload: function (event) {
                self.ractive.set("isLoading", true);
                self.service.post("/api/paa/load", null, function (model) {
                    if (model.Status) {
                        self.populateAds();
                    } else {
                        self.ractive.set("isLoading", false);
                    }
                });
            }
        });
    };
    //Initializes the datatable with the given options to provide paging and sorting.
    self.initTable = function (options) {
        self.dataTable = $('#' + self.tableName).DataTable(options);
    };
    //Generic method to loading templates and their associated data.
    self.loadData = function (path, options) {
        self.service.get(path, function (model) {
            self.initView(self.elementName, self.templateName, model);
            self.initTable(options);
        });
    };
    //Gets all the Ads for full list of Advertisers.
    self.populateAds = function () {
        self.loadData("/api/paa/ads", {
            searching: false,
            pageLength: 50,
            columnDefs: [
            ],
            scrollY: 500,
            scrollX: false,
            scrollCollapse: true,
            order: [2, "asc"]
        });
    };

    return {
        loadAds: function (elementName, templateName, tableName) {
            self.elementName = elementName;
            self.templateName = templateName;
            self.tableName = tableName;
            self.populateAds();
        },
        loadBrands: function (elementName, templateName, tableName) {
            self.elementName = elementName;
            self.templateName = templateName;
            self.tableName = tableName;
            self.loadData("/api/paa/brands", {
                searching: false,
                pageLength: 10,
                columnDefs: [
                ],
                scrollY: 500,
                scrollX: false,
                scrollCollapse: true,
                order: [2, "asc"]
            });
        },
        loadCategories: function (elementName, templateName, tableName) {
            self.elementName = elementName;
            self.templateName = templateName;
            self.tableName = tableName;
            self.loadData("/api/paa/categories", {
                searching: false,
                paging: false,
                pageLength: 10,
                columnDefs: [
                ],
                scrollY: 500,
                scrollX: false,
                scrollCollapse: true,
                order: [[0, "desc"], [2, "asc"]]
            });
        },
        loadCompanies: function (elementName, templateName, tableName) {
            self.elementName = elementName;
            self.templateName = templateName;
            self.tableName = tableName;
            self.loadData("/api/paa/companies", {
                searching: false,
                paging: false,
                pageLength: 10,
                columnDefs: [
                ],
                scrollY: 500,
                scrollX: false,
                scrollCollapse: true,
                order: [[0, "desc"], [1, "desc"], [3, "asc"]]
            });
        }
    };
};

$(document).ready(function () {
    Ractive.DEBUG = true;
});