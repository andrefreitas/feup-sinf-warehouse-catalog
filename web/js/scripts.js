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
  $.getJSON( "gate.php?action=getProductDescription&productId="+article.id, function( data ) {
      if (data['status']=='ok'){
          $("#articleName").html(data['articleDescription']['Familia']);
          $("#articlePrice").html(data['articleDescription']['Preco']);
          $("#articleStock").html(data['articleDescription']['StkAtual']);
          $("#articleIVA").html(data['articleDescription']['IVA']);
          $("#articleDescription").html(data['articleDescription']['Descricao']);
          $("#articleCode").html(data['articleDescription']['CodArtigo']);
          $("#articleImage").attr("src", "picturesproducts/" + data['articleDescription']['Imagem']);
          /*$("#articleName").html(data['articleDescription']['']);
          $("#articleName").html(data['articleDescription']['']);*/
          $('#articlePopup').bPopup({
            easing: 'easeOutBack', //uses jQuery easing plugin
            speed: 450,
            transition: 'slideDown'
          });
      }else if (data['status']=='error'){
        alert(data['reason']);
      }
    });
}