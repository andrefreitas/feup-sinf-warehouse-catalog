<?php
	chdir("common");
    require_once("init.php");

    //next example will recieve all messages for specific conversation
    $warehousesWithArticles = getJsonResponse('localhost:49300/api/artigosarmazens');
    //var_dump($decoded);

    // get warehouses
    $warehouses = getJsonResponse('localhost:49300/api/armazens');

    // get products
    $products = getJsonResponse('localhost:49300/api/artigos');
    // Template
    $smarty->assign("articles", $warehousesWithArticles);
    $smarty->assign("products", $products);
    $smarty->assign("warehouses", $warehouses);
    $smarty->display("articles.tpl");
?>