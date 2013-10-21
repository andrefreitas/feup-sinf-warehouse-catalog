<!DOCTYPE HTML>
<html>
  <head>
    <title>Warehouse Catalog</title>
    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="css/styles.css"/>
    <script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
    <script src="lib/bootstrap/js/bootstrap.min.js"></script>
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
        <img src="images/logo.svg" id="logo" height="100">
      </div>
    </div>
    <!-- Content -->
    <div class="container">
      <!-- Filter -->
      <div class="box" id="filter">
        <div class="icon">
          <img src="images/icons/settings.svg" width="33" height="33">
        </div>
        <div id="parameters">
          Armazém:
          <select>
            <option selected="selected">Qualquer um</option>
            {foreach from=$warehouses item=warehouse}
              <option value="{$warehouse.CodArmazem}">{$warehouse.Descricao}</option>
            {/foreach}
          </select>
        </div>
      </div>
      <!-- Articles -->
      <div id="articles">
        {foreach $articles as $article}
          <div class="box article">
            <div class="name">{foreach $products as $product}{if $product.CodArtigo eq $article.Artigo}{$product.Descricao|truncate:25}{/if}{/foreach}</div>
            <div class="pvp">{foreach $products as $product}{if $product.CodArtigo eq $article.Artigo}{$product.Preco|truncate:25}{/if}{/foreach} €</div>
            <div class="stock"><b>Stock</b> {$article.StockAtual}</div>
            <div class="warehouse"><img src="images/icons/warehouse.svg" width="40px">{foreach $warehouses as $warehouse}{if $warehouse.CodArmazem eq $article.Armazem}{$warehouse.Descricao|truncate:15}{/if}{/foreach}</div>
          </div>
        {/foreach}
      </div>
    </div>

  </body>
</html>