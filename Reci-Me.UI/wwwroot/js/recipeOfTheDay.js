
    function RecipeDaily() {
        var d = new Date();
        var t = d.getTime();
        var days = Math.floor(t / (86400000));

        var imagearray = new Array('/css/img/blackenedshrimptacos.jpg', '/css/img/steakonstove.jpg', '/css/img/stuffed-peppers.jpg', '/css/img/RockFishTacos.png', '/css/img/JalapenoLimeSteakTacos.png', '/css/img/BreakfastTacos.png', '/css/img/SweetPotatoBlackBeanTacos.png');
        var i = days % imagearray.length;
        i = 1;
        document.getElementById("randImg").src = imagearray[i];
        var imagetextarray = new Array('Blackened Shrimp Tacos', 'Steak on the Stovetop', 'Stuffed Peppers', 'Rock Fish Tacos', 'Jalapeno Lime Steak Tacos', 'Breakfast Tacos', 'Sweet Potato Black Bean Tacos');
        document.getElementById("randText").innerHTML = imagetextarray[i];
        document.getElementById("lnkText").innerHTML = imagetextarray[i];
        var a = document.getElementById("lnkText");
        a.href = "/Recipe/DetailsName?name=" + imagetextarray[i];

    }

        //function RandomRecipe() {
        //    let randNum = Math.floor(Math.random() * 5);
        //    let imgMod;
        //    let txtMod;
        //    if (randNum <= 1) {
        //        imgMod = document.getElementById("randImg").src = "/css/img/blackenedshrimptacos.jpg";
        //        txtMod = document.getElementById("randText").innerHTML = "Blackened Shrimp Tacos";
        //        //imgMod.style.width = 100 + "px";
        //        //imgMod.style.height = 100 + "px";
        //    } else if (randNum > 1 && randNum <= 2) {
        //        document.getElementById("randImg").src = "/css/img/steakonstove.jpg";
        //        document.getElementById("randText").innerHTML = "Steak on the Stovetop";
        //    } else if (randNum > 2 && randNum <= 3) {
        //        document.getElementById("randImg").src = "/css/img/stuffed-peppers.jpg";
        //        document.getElementById("randText").innerHTML = "Stuffed Peppers";
        //    } else {
        //        document.getElementById("randImg").src = "/css/img/wings.jpg";
        //        document.getElementById("randText").innerHTML = "Buffalo Wings";
        //    }
        //}

        //function on(picture) {
        //    console.log('On')
        //    document.getElementById("overlay").style.display = "block";
        //    document.getElementById("output").src = picture;
        //}

        //function AddToCart(id) {
        //    $.get("/ShoppingCart/AddToCart/" + id, function (data) {
        //        console.log("Starting adding " + id);
        //        var cartcount = parseInt($("#cartcount").val()) + 1
        //        $("#cartcount").val(cartcount);
        //        $("#cartcountdisp").text(cartcount + " Items");
        //    });
        //}
