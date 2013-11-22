<?php
    include_once('../lib/Smarty/Smarty.class.php');
    $smarty = new Smarty;
    $smarty->setTemplateDir("../templates");
    $smarty->setCompileDir("../templates_c/");

    // Send error messages to Smarty and delete them
    if (!isset($_SESSION['s_error']))
        $_SESSION['s_error'] = "";
    if (!isset($_SESSION['s_ok']))
        $_SESSION['s_ok'] = "";
    $smarty->assign("s_error", $_SESSION['s_error']);
    $_SESSION['s_error'] = null;
    
    // Send ok messages to Smarty and delete them
    $smarty->assign("s_ok", $_SESSION['s_ok']);
    $_SESSION['s_ok'] = null;
?>