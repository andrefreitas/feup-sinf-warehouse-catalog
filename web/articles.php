<?php
	chdir("common");
    require_once("init.php");

    // Articles
    $articles = array (
    	array("name" => "Alpinea Rosa",
    		  "warehouse" => "Gaia",
    		  "stock" => 242,
    		  "pvp" => "1,40"
    		 ),

    	array("name" => "Astromeia",
    		  "warehouse" => "Matosinhos",
    		  "stock" => 29,
    		  "pvp" => "1,62"
    		  ),
        array("name" => "Tulipa",
              "warehouse" => "Paranhos",
              "stock" => 64,
              "pvp" => "3,22"
            )
    	);
    $warehouses = array(
        array("name" => "Paranhos", "code" => "h4Sjfigh"),
        array("name" => "Gaia", "code" => "fgfggff"),
        array("name" => "Matosinhos", "code" => "m23f34")
        );
    // Template
    $smarty->assign("warehouses", $warehouses);
    $smarty->assign("articles", $articles);
    $smarty->display("articles.tpl");
?>