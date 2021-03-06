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

   $(".warehouse").click(function() {
    viewWarehouse(this);
  });

   $("#showArtWarehouse").click(function() {
    goToArticlesWarehouse();
   });

   $("#filterButton").click(function() {
    callFilteredPage();
   });

  window.onload = loadScript;

});

function viewArticle(article) {
  $.getJSON( "gate.php?action=getProductDescription&productId="+article.id, function( data ) {
      if (data['status']=='ok'){
          $("#articleName").html(data['articleDescription']['Descricao']);
          $("#articlePrice").html(data['articleDescription']['Preco']);
          $("#articleStock").html(data['articleDescription']['StkAtual']);
          $("#articleIVA").html(data['articleDescription']['IVA']);
          $('#title').html(data['articleDescription']['Descricao']);
          $("#articleDescription").html(data['articleDescription']['Descricao']);
          $("#articleCode").html(data['articleDescription']['CodArtigo']);
          $("#articleImage").attr("src", "picturesproducts/" + data['articleDescription']['Imagem']);
          wh = "";
          for (i=0; i<data['articleWarehouses'].length;i++){
            wh +=
            '<a href="articles.php?warehouse='+data['articleWarehouses'][i]['CodArmazem']+'"><div class="warehouse"><div class="name"><img src="images/icons/warehouse.svg" width="40px"><span>'
            +data['articleWarehouses'][i]['Localidade']
            +'</span></div><div class="stock">'
            +data['articleWarehouses'][i]['StkArmazem']+
            '</div></div></a>';
          } 
          $("#articleWarehouses").html(wh);
          var T = $(window).height() / 2 + $(window).scrollTop(),
                L = $(window).width() / 2 ;
          $('#articlePopup').modal('show');

      }else if (data['status']=='error'){
        alert(data['reason']);
      }
    });
  }

var geocoder;
var map;
var marker;
function viewWarehouse(warehouse) {
  $.getJSON( "gate.php?action=getWarehouseDescription&warehouseId="+warehouse.id, function( data ) {
    if (data['status']=='ok'){
        $("#warehouseDesc").html(data['warehouseDescription']['Descricao']);
        $("#warehouseMorada").html(data['warehouseDescription']['Morada']);
        $("#warehouseCodPost").html(data['warehouseDescription']['CodPostal']);
        $("#warehouseLocal").html(data['warehouseDescription']['Localidade']);
        $('#title').html(data['warehouseDescription']['Descricao']);
        $("#warehouseTelef").html(data['warehouseDescription']['Telefone']);
        $("#warehouseFax").html(data['warehouseDescription']['Fax']);
        $("#warehouseDistr").html(data['warehouseDescription']['Distrito']);
        $("#warehousePais").html(data['warehouseDescription']['Pais']);
        $("#warehouseCod").html(data['warehouseDescription']['CodArmazem']);
        if (typeof geocoder != 'undefined' && typeof map != 'undefined')
          initialize();
        geocoder.geocode({ 'address': data['warehouseDescription']['Morada']+"'"+data['warehouseDescription']['Localidade']+','+data['warehouseDescription']['CodPostal']}, function(results, status) { 

             if (status == google.maps.GeocoderStatus.OK) {
                marker = new google.maps.Marker({  map: map,  position: results[0].geometry.location });
                map.setCenter(marker.getPosition());
                map.setCenter(marker.getPosition());  
             }

             else{
                alert("Geocode was not successful for the following reason: " + status);
             }
        });
        google.maps.event.addListenerOnce(map, 'idle', function() {
          google.maps.event.trigger(map, 'resize');
          map.setCenter(marker.getPosition());
        });
        $('#warehousePopup').modal('show');
    }else if (data['status']=='error'){
      alert(data['reason']);
    }
  });
}

function initialize() {
  var mapOptions = {
    zoom: 8,
    center: new google.maps.LatLng(-34.397, 150.644)
  };

  map = new google.maps.Map(document.getElementById('map-canvas'),
      mapOptions);

  geocoder = new google.maps.Geocoder();
}

function loadScript() {
  var script = document.createElement('script');
  script.type = 'text/javascript';
  script.src = 'https://maps.googleapis.com/maps/api/js?key=AIzaSyDLosVe-YFQJuS037lmic-R3lB84sHiZ7k&v=3.exp&sensor=false&' +
      'callback=initialize';
  document.body.appendChild(script);
}

function goToArticlesWarehouse() {
    var warehouseCode = $('#warehouseCod').text();
    window.location.replace("articles.php?warehouse=" + warehouseCode);
  }

function callFilteredPage() {

  var newPage = "articles.php?";

  var warehouseSelected = $('#warehouseSelected').val();
  var lowerPrice = $('#lowerPrice').val();
  var higherPrice = $('#higherPrice').val();
  var lowerStock = $('#lowerStock').val();
  var higherStock = $('#higherStock').val();

  newPage = newPage + "warehouse=" + warehouseSelected + "&lowerPrice=" + lowerPrice + "&higherPrice=" + higherPrice + 
    "&lowerStock=" + lowerStock + "&higherStock=" + higherStock;

  window.location.replace(newPage);
}
