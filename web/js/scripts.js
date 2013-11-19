$(document).ready(function() {

  $("#recover").click(function() {
    $('#recoveryPopup').bPopup({
      easing: 'easeOutBack', //uses jQuery easing plugin
      speed: 450,
      transition: 'slideDown'
    });
  });

  $(".article").click(function() {
    viewArticle(this);
  });  

   $("#articlePopup .closePopup").click(function() {
      $('#articlePopup').bPopup().close();
      $('#articlePopup').css("display", "none");

    });
});

function viewArticle(article) {
  $('#articlePopup').bPopup({
    easing: 'easeOutBack', //uses jQuery easing plugin
    speed: 450,
    transition: 'slideDown'
  });

}