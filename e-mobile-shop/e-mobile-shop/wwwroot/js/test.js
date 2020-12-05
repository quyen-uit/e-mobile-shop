$(() => {
    var tmp;
    var number1,number2;
    let connection = new signalR.HubConnectionBuilder().withUrl("/signalServer").build()

    connection.start()

    connection.on("refreshDonHangs", function (newID, num1,num2) {
        tmp = newID;
        loadData()
        number1 = num1;
        number2 = num2;
    })
    connection.on("updateDonHangs", function (num1, num2) {
        tmp = null;
        loadData()
        number1 = num1;
        number2 = num2;
    })

    loadData();
    function show1() {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "preventDuplicates": true,
            "onclick": test,
            "showDuration": "5000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "show",
            "hideMethod": "hide"
        };
        toastr.success('Có đơn hàng mới. id: ' + tmp  );

    }
    function setNumberDonHang() {
        document.getElementById('numDH1').innerHTML = number1;
        document.getElementById('numDH2').innerHTML = number2;
    }
    function test() {
        window.location.href = "/Admin/ChiTietDonHang/" + tmp;
    }
    function loadData(){
        var tr = ''

        $.ajax({
            url: '/Admin/Test',
            method: 'GET',
            success: (result) => {
                if (tmp )
                    show1();
                if (number1 || number2)
                    setNumberDonHang();
            },
            error: (error)=>{
                console.log(error)
            }
        })
    }
})