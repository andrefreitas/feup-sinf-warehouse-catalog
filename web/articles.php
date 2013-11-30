<?php
	chdir("common");
    require_once("init.php");

    //next example will recieve all messages for specific conversation teste

    //var_dump($decoded);

    if(isset($_SESSION['s_username'])) {
        $smarty->assign("page", "articles");
        $smarty->assign("username_session", "");//$_SESSION['s_username']);
        $warehouses = getJsonResponse('localhost:49300/api/armazens');
        $smarty->assign("warehouses", $warehouses); 
        if (isset($_REQUEST['warehouse']) && $_REQUEST['warehouse']!="none"){
            $warehousesWithArticles = getJsonResponse('localhost:49300/api/artigosarmazens/'.$_REQUEST['warehouse']);
            $smarty->assign("selected", $_REQUEST['warehouse']);
        }else{
            $warehousesWithArticles = getJsonResponse('localhost:49300/api/artigosarmazens');
            $smarty->assign("selected", 'none');
            
        }
        $smarty->assign("articles", $warehousesWithArticles);
        $minValue = 1000000;
        $maxValue = 0;
        $minStock = 1000000;
        $maxStock = 0;

        $articles = getJsonResponse('localhost:49300/api/artigos');

        foreach($articles as $article) {
            $value = $article['Preco'];
            $stock = $article['StkAtual'];

            if($value < $minValue)
                $minValue = $value;

            if($value > $maxValue)
                $maxValue = $value;

            if($stock < $minStock)
                $minStock = $stock;

            if($stock > $maxStock)
                $maxStock = $stock;
        }

        $minValue = floor($minValue);
        $maxValue = ceil($maxValue);
        $minStock = floor($minStock);
        $maxStock = ceil($maxStock);

        $deltaValue = ($maxValue - $minValue) / 10;
        $deltaStock = ($maxStock - $minStock) / 10;

        $tempValue = $minValue;

        $arrayValues = array();

        while($tempValue <= $maxValue) {
            array_push($arrayValues, $tempValue);
            $tempValue = $tempValue + $deltaValue;
        }

        $tempStock = $minStock;

        $arrayStocks = array();

        while($tempStock <= $maxStock) {
            array_push($arrayStocks, $tempStock);
            $tempStock = $tempStock + $deltaStock;
        }

        $smarty->assign("priceValues", $arrayValues);
        $smarty->assign("stockValues", $arrayStocks);

        $smarty->display("articles.tpl");
    }

    else header('Location: login.php');
?>