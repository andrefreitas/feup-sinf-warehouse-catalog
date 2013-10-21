<?php
	chdir("common");
    require_once("init.php");

    //next example will recieve all messages for specific conversation

    //var_dump($decoded);
    $warehouses = getJsonResponse('localhost:49300/api/armazens');
    $products = getJsonResponse('localhost:49300/api/artigos');
    $smarty->assign("products", $products);
    $smarty->assign("warehouses", $warehouses); 
    if (isset($_REQUEST['warehouse'])){
        $warehousesWithArticles = getJsonResponse('localhost:49300/api/artigosarmazens/'.$_REQUEST['warehouse']);
        $smarty->assign("selected", $_REQUEST['warehouse']);
    }else{
        $warehousesWithArticles = getJsonResponse('localhost:49300/api/artigosarmazens');
        $smarty->assign("selected", 0);
        
    }
    $smarty->assign("articles", $warehousesWithArticles);
    $smarty->display("articles.tpl");
?>