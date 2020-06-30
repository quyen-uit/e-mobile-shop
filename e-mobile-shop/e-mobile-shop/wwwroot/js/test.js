$(() => {
    var tmp;
    let connection = new signalR.HubConnectionBuilder().withUrl("/signalServer").build()

    connection.start()

    connection.on("refreshDonHangs", function (newID) {
        tmp = newID;
        loadData()
      
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
            "showDuration": "100",
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
    function test() {
        window.location.href = "/Admin/ChiTietDonHang/" + tmp;
    }
    function loadData(){
        var tr = ''

        $.ajax({
            url: '/Admin/Test',
            method: 'GET',
            success: (result)=>{
                if(tmp)
                show1()
            },
            error: (error)=>{
                console.log(error)
            }
        })
    }
})