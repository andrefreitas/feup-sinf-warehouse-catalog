<?php
	chdir("common");
    require_once("init.php");

    //next example will recieve all messages for specific conversation teste

    //var_dump($decoded);

    $valuesSet = false;

    if(isset($_SESSION['s_username'])) {
        $smarty->assign("page", "articles");
        $smarty->assign("username_session", "");//$_SESSION['s_username']);
        $warehouses = getJsonResponse('localhost:49300/api/armazens');
        $smarty->assign("warehouses", $warehouses); 
        if (isset($_REQUEST['warehouse']) && $_REQUEST['warehouse']!="none"){
            if(isset($_REQUEST['lowerPrice']) && isset($_REQUEST['higherPrice']) && isset($_REQUEST['lowerStock']) && isset($_REQUEST['higherStock'])) {
                $lPrice = $_REQUEST['lowerPrice'];
                $hPrice = $_REQUEST['higherPrice'];
                $lStock = $_REQUEST['lowerStock'];
                $hStock = $_REQUEST['higherStock'];

                if($lPrice <= $hPrice && $lStock <= $hStock) {
                    $tempWarehousesWithArticles = getJsonResponse('localhost:49300/api/artigosarmazens/'.$_REQUEST['warehouse']);
                    $smarty->assign("selected", $_REQUEST['warehouse']);
                    $warehousesWithArticles = array();

                    foreach ($tempWarehousesWithArticles as $tempArticle) {
                        if($tempArticle['Preco'] >= $lPrice && $tempArticle['Preco'] <= $hPrice && $tempArticle['StkAtual'] >= $lStock
                            && $tempArticle['StkAtual'] <= $hStock) {
                            array_push($warehousesWithArticles, $tempArticle);
                        }
                    }

                    $smarty->assign("lPrice", $lPrice);
                    $smarty->assign("hPrice", $hPrice);
                    $smarty->assign("lStock", $lStock);
                    $smarty->assign("hStock", $hStock);

                    $valuesSet = true;
                }

                else {
                    $warehousesWithArticles = getJsonResponse('localhost:49300/api/artigosarmazens/'.$_REQUEST['warehouse']);
                    $smarty->assign("selected", $_REQUEST['warehouse']);
                }
            }

            else {
                $warehousesWithArticles = getJsonResponse('localhost:49300/api/artigosarmazens/'.$_REQUEST['warehouse']);
                $smarty->assign("selected", $_REQUEST['warehouse']);
            }
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

        if(!$valuesSet) {
            $smarty->assign("lPrice", $minValue);
            $smarty->assign("hPrice", $maxValue);
            $smarty->assign("lStock", $minStock);
            $smarty->assign("hStock", $maxStock);
        }

        $smarty->display("articles.tpl");
    }

    else header('Location: login.php');
?>