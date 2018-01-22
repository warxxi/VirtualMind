var Employee = function (salary, details) {
    this.salary = salary;
    this.details = details;
}

Employee.prototype.IncreasingSalary = function () {
    this.salary = this.salary * 1000;
}

Employee.prototype.GetDetail = function () {
    return this.details;
}

function mul(value1) {
    function mul2(value2) {
        function mul3(value3) {
            return value1 * value2 * value3;
        }
        return mul3;
    }
    return mul2;
}

function Longest_Country_Name(stringArray) {
    let newArray=stringArray.sort((itemA, itemB) => {
        return itemB.length - itemA.length;
    });

    return newArray.splice(0, 1);
}

function removecolor() {
    var select = document.querySelector('#colorSelect');
    var currentValue = select.value;
    var options = select.querySelectorAll('option');

    options.forEach(function (option, index) {
        if (option.innerHTML === select.value) {
            select.remove(index);
        }
    });
}

function insert_Row() {
    var table = document.querySelector('#sampleTable').querySelector('tbody');
    var rows = table.querySelectorAll('tr');
    var row = document.createElement('tr');

    for (var i = 0; i < 2; i++) {
        var td = document.createElement('td');
        td.innerHTML = `Row${rows.length+1} cell${i+1}`;
        row.appendChild(td);
    }

    table.appendChild(row);
}