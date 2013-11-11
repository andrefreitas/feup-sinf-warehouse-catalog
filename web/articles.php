<?php
	chdir("common");
    require_once("init.php");

    //next example will recieve all messages for specific conversation

    //var_dump($decoded);
    $warehouses = getJsonResponse('localhost:49300/api/armazens');
    $smarty->assign("warehouses", $warehouses); 
    if (isset($_REQUEST['warehouse'])){
        $warehousesWithArticles = getJsonResponse('localhost:49300/api/artigosarmazens/'.$_REQUEST['warehouse']);
        $smarty->assign("selected", $_REQUEST['warehouse']);
    }else{
        $warehousesWithArticles = getJsonResponse('localhost:49300/api/artigosarmazens');
        $smarty->assign("selected", 'none');
        
    }
    $smarty->assign("articles", $warehousesWithArticles);
    $smarty->display("articles.tpl");
?>