(function() {
    var _$modal = $('#CommunicationAideModal');
    var _$form = $('form[name=communicationaide-contactForm]');

    //Explicit Event Delegation
    $('.soonie-communicationaide-makeContact').click(function (e) {
        var request = JSON.stringify(_$form.serializeFormJSON());
//alert(request);
        MakeContact(0);
    });

    /*$('.connectionaide-requestform-criteria').change(function () {
        //Get ConnectionAide CriteriaValues
        InitFormConnectionAideCriteriaValues($(this).val(), 'checkbox');
    });
    */

    //Global Event Delegation
    /*$("body").on("click", function (ev) {
      if ($(ev.target).is("input") && $(ev.target)[0].className == 'connectionaide-requestform-criteriavalue'){
        //Get Selected Criteria
        var key = $('#connectionaide-requestform-criteria :selected')[0].text;
        var value = ev.target.value;
        var requestQuery = {"key":key,"value":value};
        console.log('"' + key + '":"' + value + '"');
        _$communicationAideRequestQuery.push(requestQuery);
      }
    });
    */


    function addLoadEvent(func) {
        var oldonload = window.onload;
        if (typeof window.onload != 'function') {
            window.onload = func;
        } else {
            window.onload = function () {
                if (oldonload) {
                    oldonload();
                }
                func();
            }
        }
    }

    $.fn.serializeFormJSON = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

    //Run event (simulate onLoad)
    //addLoadEvent(InitFormCommunicationAide);
})($); 

    var _$communicationAideTenantId = 7;
    var _$communicationAideWebApi = 'https://communicationhero.azurewebsites.net/api/services/app/';
    var _$soonieBaseAideWebApi = 'http://soonie-api.azurewebsites.net/api/services/app/';
    var _$communicationAideContactEmailFrom = document.getElementById('CommAEmailFrom').value;//'info@imanienterprisesinc.com';
    var _$communicationAideContactEmailTo = document.getElementById('CommAEmailTo').value;//'gabe@soonie.net';
    var _$communicationAideContactEmailSubject = document.getElementById('CommAEmailSubject').value;//'Interest in Imani Enterprises';
    var _$communicationAideContactEmailMessage = document.getElementById('CommAMessage').value;//'Interest in Imani Enterprises';

    function GetContactLocation(){
        var requestUrl = "http://ip-api.com/json";
        return $.ajax({
          url: requestUrl,
          type: 'GET',
          success: function(json)
          {
            console.log("My locatino is: " + JSON.stringify(json));
          },
          error: function(err){console.log("Request failed, error= " + err);}
        });
    }

    function MakeContact(callback){
        GetContactLocation().done(function(userLocation){
            //userLocation.lat
            var dataAttrib = {"Base.SendGrid.DefaultEmailAddress":_$communicationAideContactEmailTo, "Base.SendGrid.ApiKey":"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", "Base.SendGrid.Username":"azure_89c728e3c4c160eec647f9c0ab41fba3@azure.com", "Base.SendGrid.Password":"Heroes08","Base.SendGrid.IsActive":"true"};
            var messagePrepend = "ATTENTION! " + "<br/> " + document.getElementById('CommAFullName').value + " is interested.  Here is thier message:<p> " + document.getElementById('CommAMessage').value + "</p> <p>Here is their contact info:</p>" + document.getElementById('CommAEmailFrom').value;
            var data = {to:_$communicationAideContactEmailTo, from:document.getElementById('CommAEmailFrom').value, message:messagePrepend, subject:_$communicationAideContactEmailSubject, notificationType:"email",notificationChannel:0,notificationAttrib:dataAttrib,id:0};
            console.log(data);
            $('#CommASend')[0].style.display='none';
            $('#CommASendStatus')[0].style.display='block';

            //Get ConnectionAide Categories
            return $.ajax({
                url: _$soonieBaseAideWebApi + 'Notification/SendEmailNotification',
                type: 'POST',
                data: JSON.stringify(data),
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (content) {
                    console.log(content.result);
                    var result = content.result;
                    $('#CommAContactSuccess')[0].style.display='block';
                    $('#CommAContactError')[0].style.display='none';
                },
                error: function (e) { alert('err'); $('#CommAContactError')[0].style.display='block'; $('#CommAContactSuccess')[0].style.display='none'; }
            });
        });
    }

    