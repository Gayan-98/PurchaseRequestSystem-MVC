// wwwroot/js/site.js
function calculateTotal() {
    const quantity = document.getElementById('ItemQuantity').value;
    const cost = document.getElementById('ItemCost').value;
    const total = quantity * cost;
    document.getElementById('TotalCost').value = total;
}