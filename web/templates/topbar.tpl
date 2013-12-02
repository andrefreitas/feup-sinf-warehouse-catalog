<!-- Top bar -->
    <div id="top-bar">
      <div class="container"> 
        <span id="logo1"><a><img src="images/logo.svg" /><br/>&nbsp;</a></span>
        <span id="logo"><a href="logout.php"><img src="images/icons/logout.svg"/><br/>Log Out</a></span>
        <span id="logo"{if $page eq "articles"} class="selected"{/if}><a href="articles.php"><img src="images/icons/products.svg"/><br/>Produtos</a></span>
        <span id="logo"{if $page eq "warehouses"} class="selected"{/if}><a href="warehouses.php"><img src="images/icons/truck.svg"/><br/>Armazens</a></span>
      </div>
    </div>