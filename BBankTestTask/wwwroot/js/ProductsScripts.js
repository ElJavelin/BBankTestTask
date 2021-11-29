function showHideProductsRows() {
    var selector = document.getElementById("categorySelector");
    var selectorText = selector.options[selector.selectedIndex].text;

    let tRows = document.querySelectorAll('tbody tr');

    if (tRows) {
        for (i = 0; i < tRows.length; i++) {
            if (!tRows[i].classList.contains(selectorText)) {
                tRows[i].style.visibility = "collapse";
            }
            else {
                tRows[i].style.visibility = "visible";
            }
        }
    }
}

function searchProducts() {
    var searchInput = document.getElementById("searchInput");
    var searchInputText = searchInput.value;

    var tRows = document.querySelectorAll('tbody tr');

    if (tRows) {
        for (i = 0; i < tRows.length; i++) {
            var isContains = false;

            if (searchInputText.length > 0) {
                for (var j = 0, col; col = tRows[i].cells[j]; j++) {
                    if (col.innerText.includes(searchInputText)) {
                        isContains = true;
                        break;
                    }
                }
            }

            if (isContains) {
                tRows[i].style.backgroundColor = "Aquamarine";
            }
            else {
                tRows[i].style.backgroundColor = "White";
            }
        }
    }
}
