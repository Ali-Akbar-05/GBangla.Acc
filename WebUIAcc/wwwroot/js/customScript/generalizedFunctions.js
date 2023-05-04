//////
//controllerName= Controller name of the action
//actionName= Action/function name where to hit
//data= parameter of the action/function
//targetFieldId= Id of DDL field where to bind data
//defaultSelectedText =Default Selected Text like "Please Select"
//////

var datePickerOptions = {
    dateFormat: 'dd-M-yy',
    firstDay: 1,
    changeMonth: true,
    changeYear: true,
    // ...
};

function GetDayDifference(_dateFrom, _dateTo,isInclusive) {
   
    let dateFrom = new Date(_dateFrom);
    let dateTo = new Date(_dateTo);
    if (dateTo >= dateFrom) {
        // To calculate the time difference of two dates 
        let differenceInTime = dateTo.getTime() - dateFrom.getTime();
        // To calculate the no. of days between two dates 
        let differenceInDays = differenceInTime / (1000 * 3600 * 24);
        if (isInclusive) {
            differenceInDays += 1;
        }
        return differenceInDays;
    } else {
        return 0;
    }
}

function GenerateDropDown(controllerName, actionName, data, targetFieldId, defaultSelectedText) {

    var ddlTargetField = $("#" + targetFieldId);

    $.ajax({
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        url: '/' + controllerName + '/' + actionName,
        data: data,
        dataType: 'json',
        async: false,
        success: function (data) {
            ddlTargetField.html('');
            if (defaultSelectedText !== "") {
                ddlTargetField.append('<option value="">' + defaultSelectedText + '</option>');
            }
            $.each(data, function (id, option) {
                ddlTargetField.append('<option value="' + option.Value + '">' + option.Text + '</option>');
            });
            $("#AjaxLoader").hide();
        },
        error: function (request, status, error) {
            $("#AjaxLoader").hide();
            alert(request.statusText + "/" + request.statusText + "/" + error);
        }
    });
}

//////
//
function GenerateDropDownOptions(controllerName, actionName, data, defaultSelectedText) {
    debugger
    var options = "";
    $.ajax({
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        url: '/' + controllerName + '/' + actionName,
        data: data,
        dataType: 'json',
        async: false,
        success: function (data) {

            var selectedItem = "";
            if (defaultSelectedText !== "") {

                options = options + '<option value="">' + defaultSelectedText + '</option>';
            }
            $.each(data, function (id, option) {
                if (option.Selected === false) {
                    selectedItem = "";
                } else {
                    selectedItem = 'selected="selected"';
                }
                options = options + '<option value="' + option.Value + '" ' + selectedItem + ' >' + option.Text + '</option>';
            });
            //  return options;
        },
        error: function (request, status, error) {
            var options = "";
            $("#AjaxLoader").hide();
            alert(request.statusText + "/" + request.statusText + "/" + error);
        }

    });
    return options;
}

///

function GenerateDropDownCustom(controllerName, actionName, data, targetFieldId, defaultSelectedText) {

    var ddlTargetField = $("#" + targetFieldId);

    $.ajax({
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        url: '/' + controllerName + '/' + actionName,
        data: data,
        dataType: 'json',
        async: false,
        success: function (data) {
            ddlTargetField.html('');
            let dropDownItem = ""
            if (defaultSelectedText !== "") {
                ddlTargetField.append('<option value="">' + defaultSelectedText + '</option>');
            }
            $.each(data, function (id, option) {

                dropDownItem += `<option data-Custom1="${option.Custom1}" data-Custom2="${option.Custom2}" data-Custom3="${option.Custom3}" value="${option.Value}">${option.Text}</option>`;
                console.log(dropDownItem);
            });
            ddlTargetField.append(dropDownItem);
            $("#AjaxLoader").hide();
        },
        error: function (request, status, error) {
            $("#AjaxLoader").hide();
            alert(request.statusText + "/" + request.statusText + "/" + error);
        }
    });
}

///////
function GetDataList(url, data, isShowLoader) {
    if (isShowLoader && isShowLoader == 1) {
        $("#AjaxLoader").show();
    }
    var rDataList = "";
    $.ajax({
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        url: url,
        data: data,
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.result = 1) {
                rDataList = data.data;
            } else {
                rDataList = "";
            }
            if (isShowLoader && isShowLoader == 1) {
                $("#AjaxLoader").hide();
            }
        },
        error: function (request, status, error) {
            if (isShowLoader && isShowLoader == 1) {
                $("#AjaxLoader").hide();
            }
            $.alert.open("error", request.statusText + "/" + request.statusText + "/" + error);
        }

    });
    return rDataList;
}


//////
//targetFieldId=Id of DDL field;
//defaultSelectedText= Default text to show after clear;
//////
function ClearDropDown(targetFieldId, defaultSelectedText) {
    var ddlTargetField = $("#" + targetFieldId);
    ddlTargetField.html('');
    if (defaultSelectedText == "") {
        defaultSelectedText = "Please Select";
    }
    ddlTargetField.append('<option value="">' + defaultSelectedText + '</option>');
}


////////
//methodType= GET or POST;
//postUrl= Function URL, where to hit;
//objectVM= Object to create binded with model or view model;
//formClearFunction = Function name to clear form after save;

// c# function must return RResult type object

////////
function GenericSave(methodType, postUrl, objectVM, formClearFunction) {

    if (Object.keys(objectVM).length > 0) {
        if (methodType != "" && postUrl != "") {
            $("#AjaxLoader").show();
            $.ajax({
                type: methodType,
                data: objectVM,
                url: postUrl,
                dataType: "json",
                async: false,
                success: function (rResult) {
                    $("#AjaxLoader").hide();
                    if (rResult.result == 1) {
                        if (formClearFunction != "") {
                            formClearFunction();
                        }
                        $.alert.open("success", rResult.message);
                    } else {
                        $.alert.open("error", rResult.message);
                    }

                },
                failure: function (errMsg) {
                    $("#AjaxLoader").hide();
                    $.alert.open("error", errMsg);
                }
            });
        }
    } else {

        $.alert.open("error", "Error Occured");
    }
}

/// pass Success function when calling this Method
// need to Modify for success pass function
function GenericSavePassFunction(methodType, postUrl, objectVM, successOrErrorFunction, buttonHide) {

    if (Object.keys(objectVM).length > 0) {
        if (methodType != "" && postUrl != "") {
            $("#AjaxLoader").show();
            $.ajax({
                type: methodType,
                data: objectVM,
                url: postUrl,
                dataType: "json",
                async: false,
                success: function (rResult) {
                    $("#AjaxLoader").hide();
                    if (rResult.result == 1) {
                        if (formClearFunction != "") {
                            formClearFunction();
                        }
                        $.alert.open("success", rResult.message);
                    } else {
                        $.alert.open("error", rResult.message);
                    }

                },
                failure: function (errMsg) {
                    $("#AjaxLoader").hide();
                    $.alert.open("error", errMsg);
                }
            });
        }
    } else {

        $.alert.open("error", "Error Occured");
    }
}

function GenericSave(methodType, postUrl, objectVM, formClearFunction, buttonIdToHide) {

    if (Object.keys(objectVM).length > 0) {
        if (methodType != "" && postUrl != "") {
            $("#AjaxLoader").show();

            $.ajax({
                type: methodType,
                data: objectVM,
                url: postUrl,
                dataType: "json",
                async: false,
                beforeSend: function () {
                    if (buttonIdToHide != "") {
                        $("#" + buttonIdToHide).attr("disabled", true);
                    }
                },
                success: function (rResult) {
                    $("#AjaxLoader").hide();
                    if (rResult.result == 1) {
                        if (formClearFunction != "") {
                            formClearFunction();
                        }
                        $.alert.open("Success", rResult.message);
                    } else {
                        $.alert.open("error", rResult.message);
                    }
                },
                failure: function (errMsg) {
                    $("#AjaxLoader").hide();
                    $.alert.open("error", errMsg);
                },
                complete: function () {
                    $("#AjaxLoader").hide();
                    $("#" + buttonIdToHide).removeAttr("disabled");
                }
            });
        }
    } else {
        $.alert.open("error", "Error Occured");
    }
}
function GenericSaveAndRedirectToPage(methodType, postUrl, objectVM, formClearFunction, buttonIdToHide, redirectUrl) {

    if (Object.keys(objectVM).length > 0) {

        if (methodType != "" && postUrl != "") {
            $("#AjaxLoader").show();

            $.ajax({
                type: methodType,
                data: objectVM,
                url: postUrl,
                dataType: "json",
                async: false,
                beforeSend: function () {
                    if (buttonIdToHide != "") {
                        $("#" + buttonIdToHide).attr("disabled", true);
                    }
                },
                success: function (rResult) {

                    $("#AjaxLoader").hide();
                    if (rResult.result == 1) {                       
                        if (formClearFunction != "") {
                            formClearFunction();
                        }
                        $.alert.open({
                            type: 'Success',
                            content: rResult.message,
                            callback: function () {
                                if (redirectUrl != "") {
                                    window.location.replace(redirectUrl);
                                } else {
                                    window.location.reload();
                                }
                            }
                        });

                    } else {
                        $.alert.open("error", rResult.message);
                    }
                },
                failure: function (errMsg) {
                    $("#AjaxLoader").hide();
                    $.alert.open("error", errMsg);
                },
                complete: function () {
                    $("#AjaxLoader").hide();
                    $("#" + buttonIdToHide).removeAttr("disabled");
                }
            });
        }
    } else {
        $.alert.open("error", "Error Occured");
    }
}
//////
//Use of function GenericSave()
//gridLoadFunction= function name to load the grid
//////
function GenericSaveAndGridLoad(methodType, postUrl, objectVM, gridLoadFunction, formClearFunction) {

    GenericSave(methodType, postUrl, objectVM, formClearFunction);
    gridLoadFunction();
}
function GenericSaveAndGridLoad(methodType, postUrl, objectVM, gridLoadFunction, formClearFunction, buttonIdToHide) {

    GenericSave(methodType, postUrl, objectVM, formClearFunction, buttonIdToHide);
    gridLoadFunction();
}

////////
//methodType= GET or POST;
//postUrl= Function URL, where to hit;
//objectId= Primary Key to delete the object; 

// c# function must return RResult type object

////////
function GenericDeleteWithoutConfirmation(methodType, postUrl, objectId, gridLoadFunction) {
    if (parseInt(objectId) > 0) {
        if (methodType != "" && postUrl != "") {
            $.ajax({
                type: methodType,
                data: { Id: objectId },
                url: postUrl,
                dataType: "json",
                async: false,
                success: function (rResult) {

                    if (rResult.result == 1) {
                        $.alert.open("Success", rResult.message);
                        gridLoadFunction();
                    } else {
                        $.alert.open("error", rResult.message);

                    }

                },
                failure: function (errMsg) {
                    $.alert.open("error", errMsg);
                    return false;
                },
                complete: function () {
                    return true;
                }
            });
        }
    } else {
        $.alert.open("error", "Error Occured");
        return false;
    }
}

////////
//methodType= GET or POST;
//postUrl= Function URL, where to hit;
//objectId= Primary Key to delete the object; 

// c# function must return RResult type object

////////
function GenericDelete(methodType, postUrl, objectId) {
    $.alert.open('confirm', 'Are you sure to delete this record?', function (button) {
        if (button == 'yes') {
            GenericDeleteWithoutConfirmation(methodType, postUrl, objectId);
        } else {
            return false;
        }
    });
}



//////
//Use of function GenericDelete()
//gridLoadFunction= function name to load the grid
//////
function GenericDeleteAndGridLoad(methodType, postUrl, objectId, gridLoadFunction) {
    debugger
    $.alert.open('confirm', 'Are you sure to delete this record?', function (button) {
        if (button == 'yes') {
            if (parseInt(objectId) > 0) {
                if (methodType != "" && postUrl != "") {
                    $.ajax({
                        type: methodType,
                        data: { Id: objectId },
                        url: postUrl,
                        dataType: "json",
                        async: false,
                        success: function (rResult) {
                            if (rResult.result == 1) {
                                $.alert.open("Success", rResult.message);
                                gridLoadFunction();
                            } else {
                                $.alert.open("error", rResult.message);
                            }
                        },
                        failure: function (errMsg) {
                            $.alert.open("error", errMsg);
                        }
                    });
                }
            } else {
                $.alert.open("error", "Error Occured");
            }
        } else {
            return false;
        }
    });
}




///Url,AutoCompleteId,ExtrnParameter,hiddenField,extraInfoFieldId
function GenericAutoComplete(url, targetFieldId, extraParameter, hiddenField, extraInfoFieldId,callBackFunction) {
    debugger;
    try {
        var appendParameter = "";
        if (typeof extraParameter !== 'undefined' && extraParameter !== null) {
            appendParameter = extraParameter;
        }
        $("#" + hiddenField).val("");

        $("#" + targetFieldId).autocomplete({
            autoFocus: true,
            source: function (request, response) {
               
                var passData = { 'prefix': request.term.replace(".", "") };
                $.extend(passData, appendParameter);
                $.ajax({
                    url: url,
                    type: 'POST',
                    data: passData,// JSON.stringify(passData),
                    dataType: 'json',
                    success: function (data) {
                        $("#" + hiddenField).val("");
                        response(data);
                    }
                });
            },
            focus: function (event, ui) {
                  $("#" + targetFieldId).val(ui.item.AutoCompleteFocus);
                //   $("#" + hiddenField).val(ui.item.Id);
                return false;
            },

            select: function (event, ui) {
                $("#" + targetFieldId).val(ui.item.AutoCompleteSelect);
                if (typeof extraInfoFieldId !== 'undefined' && extraInfoFieldId !== null && extraInfoFieldId != "") {
                    $("#" + extraInfoFieldId).val(ui.item.InfoFieldId1);
                }
                if (typeof hiddenField !== 'undefined' && hiddenField !== null && hiddenField != "") {
                    $("#" + hiddenField).val(ui.item.ID);
                }
                if (callBackFunction!="") {
                    callBackFunction();
                }
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
                //.append('<b class="font-sz-13">' + item.AutoCompleteFocus + '</b><span style="color:#EC0F95" class="font-sz-13">(' + item.Info + ')</span>')
                .append('<span style="" class="font-sz-13">' + item.Description + '</span>')
                .appendTo(ul);
        };
    } catch (err) {
        $("#" + hiddenField).val("");
        alert("Autocomplete is not set correct way: " + err);
    }
}


function GenericAutoCompleteByClass(url, targetClassName, extraParameter, hiddenField, extraInfoFieldId) {

    try {
        var appendParameter = "";
        if (typeof extraParameter !== 'undefined' && extraParameter !== null) {
            appendParameter = extraParameter;
        }
        $("#" + hiddenField).val("");
        $('body').on('focus', "." + targetClassName, function () {
            var that = $(this);

            that.autocomplete({
                source: function (request, response) {
                    var passData = { 'prefix': request.term.replace(".", "") };
                    $.extend(passData, appendParameter);
                    $.ajax({
                        url: url,
                        type: 'POST',
                        data: passData,// JSON.stringify(passData),
                        dataType: 'json',
                        success: function (data) {
                            response(data);
                        }
                    });
                },
                focus: function (event, ui) {

                    //   var targetFieldId = event.target.id;

                    //   $("#" + targetFieldId).val(ui.item.AutoCompleteFocus);
                    return false;
                },

                select: function (event, ui) {
                    var targetFieldId = event.target.id;
                    $("#" + targetFieldId).val(ui.item.AutoCompleteSelect);
                    if (typeof extraInfoFieldId !== 'undefined' && extraInfoFieldId !== null && extraInfoFieldId != "") {
                        $("#" + extraInfoFieldId).val(ui.item.InfoFieldId1);
                    }
                    if (typeof hiddenField !== 'undefined' && hiddenField !== null && hiddenField != "") {
                        $("#" + hiddenField).val(ui.item.Id);
                    }
                    return false;
                }
            }).autocomplete("instance")._renderItem = function (ul, item) {

                return $("<li>")
                    .append('<b>' + item.AutoCompleteFocus + '</b><span style="color:#EC0F95; font-size:12px;">(' + item.Info + ')</span>')
                    .appendTo(ul);
            };
        });
    } catch (err) {
        alert("Autocomplete is not set correct way: " + err);
    }
}


function GenericAutoCompleteWithOtherInfo(url, targetFieldId, extraParameter, hiddenField, infoFieldId1, infoFieldId2, infoFieldId3) {

    try {
        var appendParameter = "";
        if (typeof extraParameter !== 'undefined' && extraParameter !== null) {
            appendParameter = extraParameter;
        }

        $("#" + targetFieldId).autocomplete({
            source: function (request, response) {
                var passData = { 'prefix': request.term.replace(".", "") };
                $.extend(passData, appendParameter);
                $.ajax({
                    url: url,
                    type: 'POST',
                    data: passData,// JSON.stringify(passData),
                    dataType: 'json',
                    success: function (data) {

                        response(data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#" + targetFieldId).val(ui.item.AutoCompleteFocus);
                return false;
            },

            select: function (event, ui) {

                $("#" + targetFieldId).val(ui.item.AutoCompleteSelect);
                if (typeof hiddenField !== 'undefined' && hiddenField !== null && hiddenField != "") {
                    $("#" + hiddenField).val(ui.item.Id);
                }
                if (typeof infoFieldId1 !== 'undefined' && infoFieldId1 !== null) {
                    $("#" + infoFieldId1).val(ui.item.InfoFieldId1);
                }
                if (typeof infoFieldId2 !== 'undefined' && infoFieldId2 !== null) {
                    $("#" + infoFieldId2).val(ui.item.InfoFieldId2);
                }
                if (typeof infoFieldId3 !== 'undefined' && infoFieldId3 !== null) {
                    $("#" + infoFieldId3).val(ui.item.InfoFieldId3);
                }


                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
                .append('<b>' + item.AutoCompleteFocus + '</b><span style="color:#EC0F95; font-size:12px;">(' + item.Info + ')</span>')
                .appendTo(ul);
        };
    } catch (err) {
        alert("Autocomplete is not set correct way: " + err);
    }
}


function GenericColorSwatchModal(modalId, url, swatchModel) {
    if (swatchModel != null) {
        $("#" + modalId).dialog({
            autoOpen: false,
            width: 800,
            resizable: false,
            draggable: true,
            title: "Pick Your Color Here",
            model: true,
            show: 'slideDown',
            closeText: 'X',
            dialogClass: 'alert',
            //position: { my: 'top', at: 'top+50' },
            closeOnEscape: true,
            open: function (event, ui) {
                $("#" + modalId).load(url, swatchModel);
            },

            close: function () {
                $(this).dialog('close');
            }

        });
    }
}

function checkDuplicateIdList() {
    var ids = [], // List of known IDs
        dupes = [],
        $list = $('ul');

    $('body').find('[id]').each(function () {
        if (this.id) {
            if (!/^[A-Za-z]/.test(this.id)) {
                $list.append('<li>The ID <code>#' + this.id + '</code> is not valid; it must begin with a letter</li>');
            }
            else {
                ids.push(this.id);
            }
        }
    });

    // Count occurences of each ID
    $.each(ids, function (i, id) {
        var regex = new RegExp('\\b' + id + '\\b', 'g'),
            numMatches = ids.join(',').match(regex).length;

        if (numMatches > 1 && dupes.indexOf(id) === -1) {
            $list.append('<li style="color:red;"><code>#' + id + '</code> is being used in ' + numMatches + ' places</li>');
            dupes.push(id);
        }
        else if (numMatches === 1) {
            $list.append('<li style="color:green;"><code>#' + id + '</code> OK</li>');
        }
    });
    //console.log($list);
}


// Generic GET AND Post Data
function GenericGetObject(methodType, postUrl, objectVM, IsLoader = false) {
    var obj = "";
    if (Object.keys(objectVM).length > 0) {
        if (methodType != "" && postUrl != "") {
            if (IsLoader) {
                $("#AjaxLoader").show();
            }
            $.ajax({
                type: methodType,
                data: objectVM,
                url: postUrl,
                dataType: "json",
                async: false,
                success: function (rResult) {
                    if (IsLoader) {
                        $("#AjaxLoader").hide();
                    }
                    if (rResult.result == 1) {

                    } else {
                        $.alert.open("error", rResult.message);
                    }
                    obj = rResult.data;
                },
                failure: function (errMsg) {
                    if (IsLoader) {
                        $("#AjaxLoader").hide();
                    }
                    $.alert.open("error", errMsg);
                }
            });
        }
    } else {

        $.alert.open("error", "Error Occured");
    }
    return obj;
}
function RtnRoundNumber(num) {
    return Math.round(num) || 0;
}
function RtnNumber(num) {
    return parseInt(num) || 0;
}

function RtnBool(num) {

    var rtn = null;
    if (!num) {
        return rtn;
    } else {
        rtn = RtnNumber(num) == 1 ? true : false;
    }
    return rtn;

}

function RtnBoolToLower(value) {

    return value == "True" ? true : false;

}

function RtnFloat(value) {
    value = value == undefined ? 0 : value;
    value = value == "" ? 0 : value;
    return parseFloat(value);
}
function RtnFloatUpToPrecision(value, precision) {

    if (precision == "") {
        precision = 2;
    }

    value = RtnFloat(value).toFixed(precision);

    return parseFloat(value);
}

function GenerateDropDownJsonString(ddlObject, targetFieldId) {
    //<option value="" selected=""disabled="disabled" ></option>
    // Disabled = dd, Group = "", Selected = "", Text = "", Value = ""
    console.log(ddlObject)
    let rtnObject = "";
    try {
        if (ddlObject == null || ddlObject.length == 0) {
            rtnObject = '<option value=""  >Please Select</option>';
        } else {
            for (var i = 0; i < ddlObject.length; i++) {
                let text = ddlObject[i].Text;
                let _value = ddlObject[i].Value;

                if (ddlObject[i].Selected !== true) {
                    selectedItem = "";
                } else {
                    selectedItem = 'selected="selected"';
                }

                rtnObject = rtnObject + '<option ' + selectedItem + ' value="' + ddlObject[i].Value + '"    >' + ddlObject[i].Text + '</option>'
            }
        }
        $("#" + targetFieldId).html(rtnObject);

    } catch (err) {
        alert("dropdown load " + err);
    }
}

function CurrencyReturn(curr, rate) {

    var amount = curr * rate;
    return amount;
};

/**
  * @param{[Amount]}   Main Amount
  * @param{[EXRate]}  Convertion Rate
  * @param{[Type]}  0 =Converted  Amount
 */

function CalculateAmountWRTCurrency(Amount, EXRate, Type) {
    var FinalAmount = 0;
    if (Type == 0) //for display
    {
        if (EXRate != 0)

            FinalAmount = eval(Amount) / eval(EXRate)
        else
            FinalAmount = eval(Amount)
    }
    else  // for save xml
    {
        if (EXRate != 0)
            FinalAmount = eval(Amount) * eval(EXRate)
        else
            FinalAmount = eval(Amount)
    }
    return RtnFloatUpToPrecision(FinalAmount, 4);
}

function IsChecked(chkBoxId) {
    var rtn = false;
    if ($('#' + chkBoxId).is(':checked')) {
        rtn = true;
    }
    return rtn;
}

function DateFormat_dd_mm_yyyy(date, separateBy) {

    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = Math.abs(parseInt(d.getFullYear()));

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;
    if (separateBy == '' || typeof separateBy === 'undefined') {
        separateBy = '-'
    }
    return [day, month, year].join(separateBy);
}

function checkNumeric(event) {
    debugger;
    var key = window.event ? event.keyCode : event.which;
    if (event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 46
        || event.keyCode == 37 || event.keyCode == 39) {
        return true;
    }
    if (event.which === 13) {
        $.next().focus();
    }
    else if (key < 48 || key > 57) {
        return false;
    }
    else return true;
}

function checkDecimal(event) {
    
    debugger;
    var key = window.event ? event.keyCode : event.which;//|| event.keyCode == 46
 /*
    if (event.which === 13) {
        $(this).next().focus();
    }
    if (key == 46) {
        var element = event.target.id;
        var findDecimal = $('#' + element).val();
        var isExist = ".";
        if (findDecimal.indexOf(isExist) != -1) {
            return false;
        } else {
            return true;
        }

    } 
    */
 
    // var key = e.charCode || e.keyCode || 0;
            // allow backspace, tab, delete, enter, arrows, numbers and keypad numbers ONLY
            // home, end, period, and numpad decimal
    if (
        key == 8 ||
        key == 9 ||
        key == 13 ||
        key == 46 ||
        key == 110 ||
        key == 190 ||
        (key >= 35 && key <= 40) ||
        (key >= 48 && key <= 57) ||
        (key >= 96 && key <= 105)) {
        return true;
    } else {
        return false;
    }

   /*  */

   // else return true;
}
function numericsOnly() {
    if ((window.event.keyCode >= 48 && window.event.keyCode <= 58)
        || window.event.keyCode == 46
        || (window.event.keyCode >= 96 && window.event.keyCode <= 105)
        || (window.event.keyCode >= 35 && window.event.keyCode <= 40)
        || window.event.keyCode == 190
        || window.event.keyCode == 110
        || window.event.keyCode == 13
        || window.event.keyCode == 9
        || window.event.keyCode == 8

    )
    {
       
        if (window.event.keyCode == 190 || window.event.keyCode == 110) {
            var element = window.event.target.id;
            if (element != "") {
                var findDecimal =  $('#' + element).val();
                var isExist = ".";
                if (findDecimal.indexOf(isExist) != -1) {
                    window.event.returnValue = false
                } else {

                }
            }
        }
    }
    else {
        window.event.returnValue = false
    }
}