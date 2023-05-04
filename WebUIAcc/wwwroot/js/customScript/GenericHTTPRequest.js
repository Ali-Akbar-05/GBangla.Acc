var HttpRequest = {

    /* @description Ajax function
    * @param {method} GET,POST,PUT.
    * @param {url} /Area/Controller/Action
    * @param {data} Parameter
    * @param {successCallBack}  Success inner Function
    * @param {errorCallBack}  Error inner Function
    * @param {loader}  Ajax loader
    */
    Ajax: function (method, url, data, successCallBack, errorCallBack, loader = false) {
      
        if (loader == true) {
            $(".loadingImage").show();
        }
        let ajaxObj = $.ajax({
            type: method.toUpperCase(),
            url: url,
            data: data,
            dataType: 'json',
            async: false,
            cache: false,
            success: successCallBack,
            error: function (err, type, httpStatus) {

                // if (typeof(errorCallBack) !== "undefined" || errorCallBack != "") {
                if (errorCallBack) {
                    errorCallBack;
                } else {
                    HttpRequest.FailureCallback(err, type, httpStatus);
                }
                if (loader == true) {
                    $(".loadingImage").hide();
                }
            },
            complete: function () {

                if (loader === true) {
                    $(".loadingImage").hide();
                }
            }
        });
        return ajaxObj;
    },
    AjaxData: function (method, url, data) {
        let returnData = "";
        $.ajax({
            type: method.toUpperCase(),
            url: url,
            data: data,
            dataType: 'json',
            async: false,
            cache: false,
            success: function (data) {
                returnData = data;
            },
            error: function (err, type, httpStatus) {
                HttpRequest.FailureCallback(err, type, httpStatus);
            }
        });
        return returnData;
    },


    /* @description Ajax function.
    * @param {method} GET,POST,PUT.
    * @param {url} /Area/Controller/Action
    * @param {data} Parameter
    * @param {targetFieldId}   Selected Dropdown Field
    * @param {loader}  Ajax loader
    */
    DropDown: function (method, url, data, targetFieldId, loader = false) {
       // debugger;
        let ddlTargetField = $("#" + targetFieldId);
        if (loader == true) {
            $(".loadingImage").show();
        }
        let ajaxObj = $.ajax({
            type: method.toUpperCase(),
            url: url,
            data: data,
            dataType: 'json',
            async: false,
            cache: false,
            success: function (data) {
                 
                let hasGroupData = IsArrayHasGroupData(data);
                let _options = "";
                ddlTargetField.html('');
                if (hasGroupData == false) {
                  
                    console.log(data);
                    $.each(data, function (id, option) {
                        _options += '<option value="' + option.Value + '">' + option.Text + '</option>';
                    });
                } else {
                    _options = dropdownGroupOption(data);
                }
                ddlTargetField.append(_options);


                if (loader == true) {
                    $(".loadingImage").hide();
                }

            },
            error: function (err, type, httpStatus) {
                if (loader == true) {
                    $(".loadingImage").hide();
                }
                HttpRequest.FailureCallback(err, type, httpStatus);
            }
        });
        return ajaxObj;
    },

    DropDownCustom: function (method, url, data, targetFieldId, loader = false) {

        let ddlTargetField = $("#" + targetFieldId);
        if (loader == true) {
            $(".loadingImage").show();
        }
        let ajaxObj = $.ajax({
            type: method.toUpperCase(),
            url: url,
            data: data,
            dataType: 'json',
            async: false,
            cache: false,
            success: function (data) {

                ddlTargetField.html('');
                var _options = "";
                $.each(data, function (id, option) {
                    _options += `<option data-Custom1="${option.Custom1}" data-Custom2="${option.Custom2}" data-Custom3="${option.Custom3}" data-Custom4="${option.Custom4}" data-Custom5="${option.Custom5}" value="${option.Value}">${option.Text}</option>`;
                });
                ddlTargetField.append(_options);
                if (loader == true) {
                    $(".loadingImage").hide();
                }

            },
            error: function (err, type, httpStatus) {
                if (loader == true) {
                    $(".loadingImage").hide();
                }
                HttpRequest.FailureCallback(err, type, httpStatus);
            }
        });
        return ajaxObj;

    },

    DropDownOptions: function (method, url, data) {
        let options = "";
        $.ajax({
            type: method.toUpperCase(),
            url: url,
            data: data,
            dataType: 'json',
            async: false,
            cache: false,
            success: function (data) {
                let hasGroupData = IsArrayHasGroupData(data);
                if (hasGroupData == false) {
                    $.each(data, function (id, option) {
                        if (option.Selected === false) {
                            selectedItem = "";
                        } else {
                            selectedItem = 'selected="selected"';
                        }
                        options = options + '<option value="' + option.Value + '" ' + selectedItem + ' >' + option.Text + '</option>';
                    });
                } else {
                    options = dropdownGroupOption(data);
                }


            },
            error: function (err, type, httpStatus) {
                HttpRequest.FailureCallback(err, type, httpStatus);
            }
        });

        return options;
    },

    DropDownDefault: function (targetFieldId) {
        let ddlTargetField = $("#" + targetFieldId);
        ddlTargetField.html('<option value="">Please Select</option>');
    },

    FailureCallback: function (err, type, httpStatus) {
        //debugger;
        var result = 0;
        var title = "";
        var message = "";
        var failureMessage = "";
        console.log(err);
        if (err.status == 400) {
            title = err.statusText;
            failureMessage = err.statusText;
        }
        else if (err.responseJSON.result == 99) {

            title = err.responseJSON.message;
            if (err.responseJSON.Errors.length > 0) {
                $.each(err.responseJSON.Errors, function (i, v) {
                    failureMessage += `<b>${v.PropertyName}:</b> ${v.ErrorMessage} <br/>`;
                });
            }
            $.alert.open('error', title, failureMessage);

        }
        else {
            failureMessage = 'Error occurred in ajax call' + err.status + " - " + err.responseText + " - " + httpStatus;

        }
        $.alert.open('error', title, failureMessage);

        console.log(failureMessage);
    },

    Select2GroupData: function (data) {
        var singleObject = {
            "text": "",
            "children": [
                {
                    "id": "",
                    "text": ""
                }
            ]
        };

        if (data == null) {
            return {
                "text": "",
                "children": [{}]
            }
        }

        const result = data.reduce((gdata, d) => {
            if (d.Value != "") {
                const found = gdata.find(a => a.text === d.Group.Name);
                const value = { id: d.Value, text: d.Text };
                if (found) {
                    found.children.push(value);
                }
                else {
                    gdata.push({ text: d.Group.Name, children: [{ id: d.Value, text: d.Text }] });
                }
            }
            return gdata;
        }, []);

        return result;

    },
    Select2NormalData: function (data,) {
        var singleObject = {
            "text": "",
            "children": [
                {
                    "id": "",
                    "text": ""
                }
            ]
        };

        if (data == null) {
            return {
                "text": "",
                "id": ""
            }
        }
     
    },

    DropDownSelect2: function (method, url, paramData, targetFieldId, loader = false) {
        let ddlTargetField = $("#" + targetFieldId);
        ddlTargetField.html("");
        ddlTargetField.select2("destroy");

        ddlTargetField.select2({
           // minimumInputLength: 0,
            ajax: {
                url: url,
                dataType: 'json',
                delay: 250,
                type: method.toUpperCase(),
                data: function (params) {
                    paramData['predict'] = params.term;
                    return paramData;
                },
                processResults: function (data, params) {
                    return {
                        results: $.map(data, function (item) {
                            return { id: item.Value, text: item.Text };
                        })
                    }                   
                }
            }
        })
    },

    DropDownSelect2Group: function (method, url, paramData, targetFieldId, loader = false) {
      
        let ddlTargetField = $("#" + targetFieldId);
        ddlTargetField.html("");
        ddlTargetField.select2("destroy");

        ddlTargetField.select2({
            placeholder: 'Please Select',
            minimumInputLength: 0,
            ajax: {
                url: url,
                dataType: 'json',
                delay: 250,
                type: method.toUpperCase(),                
                data: function (params) {
                            
                    paramData['predict'] = params.term;
                    return paramData;
                },
                processResults: function (data, params) {
                    var res =  HttpRequest.Select2GroupData(data);
                    return {
                        results: res
                    }
                }
            }
        })
    },

    DropDownSelect2Tag: function (method, url, paramData, targetFieldId, cssClass = "", loader = false) {
       // debugger;
        let ddlTargetField = $(targetFieldId);
        ddlTargetField.html("");
/*        ddlTargetField.select2("destroy");*/

        ddlTargetField.select2({
            // minimumInputLength: 0,
            dropdownCssClass: cssClass,
            ajax: {
                url: url,
                dataType: 'json',
                delay: 250,
                type: method.toUpperCase(),
                data: function (params) {
                    paramData['predict'] = params.term;
                    return paramData;
                },
                processResults: function (data, params) {
                    return {
                        results: $.map(data, function (item) {
                            return { id: item.Value, text: item.Text };
                        })
                    }
                }
            }
        })
    },

    DropDownSelect2TagGroup: function (method, url, paramData, targetFieldId, cssClass="",loader = false) {
        
        let ddlTargetField = $(targetFieldId);
        ddlTargetField.html("");
        /*        ddlTargetField.select2("destroy");*/

        ddlTargetField.select2({
            // minimumInputLength: 0,
            dropdownCssClass: cssClass,
            ajax: {
                url: url,
                dataType: 'json',
                delay: 250,
                type: method.toUpperCase(),
                data: function (params) {
                    paramData['predict'] = params.term;
                    return paramData;
                },
                processResults: function (data, params) {
                    var res = HttpRequest.Select2GroupData(data);
                    return {
                        results: res
                    }
                }
            }
        })
    },

    

}
function IsArrayHasGroupData(arraydata)
{
    let hasGorup = false;
    if (arraydata != null) {
        let sl = 0;
        $.each(arraydata, function (k,item)
        {
            sl = sl + 1;
            if (item.Group != null)
            {
                hasGorup = true;
                return false;
            }
            if (sl > 4) {
                return false;
            }
            
        })
    }
    return hasGorup;
}
function dropdownGroupOption(arraydata)
    {
        let optgroup = "";
        let oldGroupLabel = "";
        let itemCount = 0;
        $.each(arraydata, function (k, item) {
            if(item.Group == null) {
                optgroup = `<option value="">${item.Text}</option>`;
            }
            if (item.Group != null) {
            
                if ( oldGroupLabel == item.Group.Name) {
                    optgroup += `<option value="${item.Value}">${item.Text}</option>`;
                }
                if (oldGroupLabel != item.Group.Name) {
                    if (itemCount > 0) {
                        optgroup = `</optgroup>`;
                    }
                    optgroup += `<optgroup label="${item.Group.Name}">`;

                    optgroup += `<option value="${item.Value}">${item.Text}</option>`;
                }

                if (oldGroupLabel != item.Group.Name) {
                    oldGroupLabel = item.Group.Name;
                    itemCount = itemCount + 1;
                }
            }
        });

        if (itemCount > 0) {
            optgroup += `</optgroup>`;
        }
        return optgroup;
    }