let MAIN = {
    onAddCardClick: function (e) {
        const jqCard = $(`
            <div class="col-sm-3 mt-2">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">제목</h5>
                        <h6 class="card-subtitle mb-2 text-muted">서브제목</h6>
                        <p class="card-text">블라블라</p>
                        <a href="#" class="card-link">Red</a>
                        <a href="#" class="card-link">Green</a>
                    </div>
                </div>
            </div>
        `);

        jqCard.hide();
        $("#cardGroupDiv").append(jqCard);
        jqCard.show("normal");
    }
};



$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar, #content').toggleClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });

    $("#addCardBtn").on("click", MAIN.onAddCardClick);
});