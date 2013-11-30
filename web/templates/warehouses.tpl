<!DOCTYPE HTML>
<html>
  <head>
    <title>Warehouse Catalog</title>
    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="css/styles.css"/>
    <script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
    <script src="lib/bootstrap/js/bootstrap.min.js"></script>
    <script src="js/scripts.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />
    <link rel="apple-touch-icon" href="images/icons/ipad-icon.png"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta charset="utf-8">
  </head>
  <body>
    {include file='topbar.tpl'}
    <!-- Content -->
    <div class="container">
      <!-- Filter -->
      <div class="box" id="filter">
        <div class="icon">
          <img src="images/icons/settings.svg" width="33" height="33">
        </div>
      </div>
      <!-- Articles -->
      <div id="warehouses">
        {foreach $warehouses as $warehouse}
          <div class="box warehouse" id="{$warehouse.CodArmazem}">
            <div class="description" >{$warehouse.Descricao|truncate:40}</div>
            <div class="city"> {$warehouse.Localidade|truncate:25} </div>
            <div class="phone"><img src="images/icons/phone.svg" width="40px">{$warehouse.Telefone|truncate:15}</div>
          </div>
        {/foreach}
      </div>
    </div>



    <!-- Warehouse Popup-->

    <!-- Modal -->
    <div class="modal fade" id="warehousePopup" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h4 class="modal-title" id="title"></h4>
          </div>
          <div class="modal-body">
            <div class="content">
              <div class="description">
                <span><b>Código: </b><span id="warehouseCod"></span></span>
              </div>
              <div class="description">
                <span><b>Morada: </b><span id="warehouseMorada"></span></span>
              </div>
              <div class="description">
                <span><b>Localidade: </b><span id="warehouseLocal"></span></span> <span><b>Código Postal: </b><span id="warehouseCodPost"></span></span>
              </div>
              <div class="description">
                <span><b>Distrito: </b><span id="warehouseDistr"></span></span> <span><b>País: </b><span id="warehousePais"></span></span>
              </div>
              <div class="description">
                <span><b>Telefone: </b><span id="warehouseTelef"></span></span> <span><b>Fax: </b><span id="warehouseFax"></span></span>
              </div>
              <div id="map-canvas"></div>
            </div>
          </div>
          <div class="modal-footer">
            <button id="showArtWarehouse" type="button" class="btn btn-primary">Ver artigos</button>
            <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
          </div>
        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
  </body>
</html>