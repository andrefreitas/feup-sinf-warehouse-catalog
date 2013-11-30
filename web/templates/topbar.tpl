<!-- Top bar -->
    <div id="top-bar">
      <div class="container"> 
        <span id="logo1"><a><img src="images/logo.svg" /><br/>&nbsp;</a></span>
        <span id="logo"><a href="logout.php"><img src="images/icons/logout-menu.png"/><br/>Log Out</a></span>
        <span id="logo"{if $page eq "home"} class="selected"{/if}><a href="index.php"><img src="images/icons/home.png"/><br/>Home</a></span>
        <span id="logo"{if $page eq "articles"} class="selected"{/if}><a href="articles.php"><img src="images/icons/produtos-menu.png"/><br/>Produtos</a></span>
        <span id="logo"{if $page eq "warehouses"} class="selected"{/if}><a href="warehouses.php"><img src="images/icons/warehouse-menu.png"/><br/>Armazens</a></span>
      </div>
    </div>