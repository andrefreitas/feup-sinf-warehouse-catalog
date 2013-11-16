$("#myButton").on("click", function(){
  $.ajax({
      type : "GET",
      url: 'http://localhost:49300/api/armazens',
      dataType: 'jsonp',
      success: function(dataWeGotViaJsonp){
          var text = '';
          var len = dataWeGotViaJsonp.length;
          for(var i=0;i<len;i++){
              twitterEntry = dataWeGotViaJsonp[i];
              text += '<p><img src = "' + twitterEntry.user.profile_image_url_https +'"/>' + twitterEntry['text'] + '</p>'
          }
          alert(text);
      }
  });
});

/*$(document).ready(function() {
  $("#loginForm").on("submit", function() {

    var email1 = $("#exampleInputEmail1").val();
    var password1 = $("#exampleInputPassword1").val();

    var postData = "email="+email1+"&password="+password1;

    alert(email1);
    alert(password1);

    $.ajax({
      type : "POST",
      url: 'http://localhost:49300/api/utilizadores',
      data: postData,
      dataType: 'json',
      success: function(d){
         alert("entrou");
      },
      error: function(d) {
        alert("fail");
      }
    });

    return false;
  });
});*/