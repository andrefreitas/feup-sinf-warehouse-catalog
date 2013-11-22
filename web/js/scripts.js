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
          $("#articleName").html(data['articleDescription']['Descricao']);
          $("#articlePrice").html(data['articleDescription']['Preco']);
          $("#articleStock").html(data['articleDescription']['StkAtual']);
          $("#articleIVA").html(data['articleDescription']['IVA']);
          $("#articleDescription").html(data['articleDescription']['Descricao']);
          $("#articleCode").html(data['articleDescription']['CodArtigo']);
          $("#articleImage").attr("src", "picturesproducts/" + data['articleDescription']['Imagem']);
          wh = "";
          for (i=0; i<data['articleWarehouses'].length;i++){
            wh +=
            '<div class="warehouse"><div class="name"><img src="images/icons/warehouse.svg" width="40px"><span>'
            +data['articleWarehouses'][i]['Localidade']
            +'</span></div><div class="stock">'
            +data['articleWarehouses'][i]['StkArmazem']+
            '</div></div>';
          } 
          $("#articleWarehouses").html(wh);
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