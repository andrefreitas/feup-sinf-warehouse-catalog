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

    // Template
    $smarty->assign("articles", $articles);
    $smarty->display("articles.tpl");
?>