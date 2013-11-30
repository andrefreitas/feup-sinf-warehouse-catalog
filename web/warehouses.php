<?php
	chdir("common");
    require_once("init.php");

    //next example will recieve all messages for specific conversation teste

    //var_dump($decoded);

    if(isset($_SESSION['s_username'])) {
        $smarty->assign("page", "warehouses");
        $smarty->assign("username_session", $_SESSION['s_username']);
        $warehouses = getJsonResponse('localhost:49300/api/armazens');
        $smarty->assign("warehouses", $warehouses);


        $smarty->display("warehouses.tpl");
    }

    else header('Location: login.php');
?>