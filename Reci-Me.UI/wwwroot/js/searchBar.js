var infoLoaded = 0;
function loadSearchData() {

    if (infoLoaded == 0) {
    let recipes = [
        'Blackened Shrimp Tacos',
        'Steak on the Stovetop',
        'Stuffed Peppers',
        'Pasta Fazool',
        'Italian BLT',
        'Traditional Gyro',
        'Gorditas',
        'Tyrokafteri',
        'Seasoned Turkey Burgers',
        'Waffles',
        'Pastitsio',
        'Venison Gyros',
        'Carne Asada Torta',
        'Honey Mustard Mac Salad',
        'Greek Salad',
        'Texas Chili',
        'Grilled Chicken Street Tacos',
        'American Goulash',
        'Asparagus Casserole',
        'Dakos',
        'Tzatziki Sauce',
        'Sopes',
        'Mexican Rice'
    ];
    // Get the HTML element of the list
    let list = document.getElementById('list');
    // Add each data item as an <a> tag
    recipes.forEach((recipe) => {
        let a = document.createElement("a");
        a.innerText = recipe;
        a.href = "/Recipe/DetailsName?name=" + recipe;
        a.classList.add("listItem");
        list.appendChild(a);
    });
        infoLoaded++;
    }
}

function search() {
    let listContainer = document.getElementById('list');
    let listItems = document.getElementsByClassName('listItem');
    let input = document.getElementById('searchbar').value
    input = input.toLowerCase();
    let noResults = true;
    for (i = 0; i < listItems.length; i++) {
        if (!listItems[i].innerHTML.toLowerCase().includes(input) || input === "") {
            listItems[i].style.display = "none";
            continue;
        }
        else {
            listItems[i].style.display = "flex";
            noResults = false;
        }
    }
    listContainer.style.display = noResults ? "none" : "block";
}
