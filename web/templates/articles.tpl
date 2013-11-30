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
    <!-- Top bar -->
    <div id="top-bar">
      <div class="container">
        <img src="images/logo.svg" id="logo" height="100"/>
        <span id="logoutButton"><a href="logout.php"> <img src="images/logout.svg" height="25px" /></a></span>
      </div>
    </div>
    <!-- Content -->
    <div class="container">
      <!-- Filter -->
      <div class="box" id="filter">
        <div class="icon">
          <img src="images/icons/settings.svg" width="33" height="33" data-toggle="modal" data-target="#configurationPopup"/>
        </div>
        <div id="parameters">
          Armazém:
          <select onchange="location = 'articles.php?warehouse='+this.options[this.selectedIndex].value;">
            <option {if $selected eq 'none'}selected{/if} value="none">Qualquer um</option>
            {foreach from=$warehouses item=warehouse}
              <option {if $selected eq $warehouse.CodArmazem}selected{/if} value="{$warehouse.CodArmazem}">{$warehouse.Descricao}</option>
            {/foreach}
          </select>
        </div>
      </div>
      <!-- Articles -->
      <div id="articles">
        {foreach $articles as $article}
          <div class="box article" data-toggle="modal" data-target="#articlePopup" id="{$article.CodArtigo}">
            <div class="name" >{$article.DescArtigo|truncate:25}</div>
            <div class="pvp">{$article.Preco|truncate:25} €</div>
            <div class="stock"><b>Stock</b> {$article.StkAtual}</div>
            <div class="warehouse1"><img src="images/icons/warehouse.svg" width="40px">{$article.DescArmazem|truncate:15}</div>
          </div>
        {/foreach}
      </div>
    </div>



    <!-- Article Popup-->

    <!-- Modal -->
    <div class="modal fade" id="articlePopup" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h4 class="modal-title" id="title"></h4>
          </div>
          <div class="modal-body">
            <div class="content">
              <div class="description">
                <img id="articleImage" src="" />
                <span class="text"><b>Preço:</b> <span id="articlePrice"></span> &euro;</span>
                <br/>
                <span class="text"><b>Stock:</b> <span id="articleStock"></span></span>
              </div>
              <div class="info">
                  <span><b>Código:</b> <span id="articleCode"></span></span>
                  <span><b>IVA:</b> <span id="articleIVA"></span>%</span>
              </div>
              <div class="warehouses" id='articleWarehouses'>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
          </div>
        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->

     <!-- Configuration Popup-->

    <!-- Modal -->
    <div class="modal fade" id="configurationPopup" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h4 class="modal-title">Filtrar</h4>
          </div>
          <div class="modal-body">
            <div class="content">
              <div class="description">
                <span class="text">
                  Armazém:
                  <select id="warehouseSelected">
                    <option {if $selected eq 'none'}selected{/if} value="none">Qualquer um</option>
                    {foreach from=$warehouses item=warehouse}
                      <option {if $selected eq $warehouse.CodArmazem}selected{/if} value="{$warehouse.CodArmazem}">{$warehouse.Descricao}</option>
                    {/foreach}
                  </select>
                </span>
              </div>
              <div class="info">
                <span class="text">
                  Preço entre 
                  <select id="lowerPrice">

                  </select> e 
                  <select id="higherPrice">

                  </select>
                </span>
              </div>
              <div class="info">
                <span class="text">
                  Stock entre
                  <select id="lowerStock">

                  </select> e 
                  <select id="higherStock">
                  
                  </select> 
                </span>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button id="filterButton" type="button" class="btn btn-primary">Filtrar</button>
            <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
          </div>
        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->

  </body>
</html>