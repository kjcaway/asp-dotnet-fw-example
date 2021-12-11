

let MAIN = {
    init: function () {
        $('#tree').treeview({
            data: getTree(),
            expandIcon: 'fa fa-chevron-down',
            collapseIcon: 'fa fa-chevron-up'
        });
        
        $('#tree').on('nodeSelected', function (event, data) {
            console.log('nodeSelected ' + data.nodeId);
            MAIN.showLeftSelectedNode(data);
        });

        $('#tree').on('nodeUnselected', function (event, data) {
            console.log('nodeUnselected ' + data.nodeId);
            MAIN.hideLeftSelectedNode(data);
        });

        $('#add-btn').on('click', function () {
            let selected = $('#tree').treeview('getSelected');
            console.log(selected);

            if (selected.length > 0) {
                $('#tree').treeview('addNode', [{
                    text: "Added Node"
                }, selected[0], 0, { silent: true }]);
            }
        });
        $('#delete-btn').on('click', function () {
            let selected = $('#tree').treeview('getSelected');
            console.log(selected);

            if (selected.length > 0) {
                $('#tree').treeview('removeNode', [selected[0], { silent: true }]);
            }
        });
    },
    showLeftSelectedNode: function (data) {
        $("#info-node").html("");
        $("#info-node").html(`
            <h5>${data.text}</h5>
            <ui>
                <li>id : ${data.nodeId}</li>
                <li>desc : ${data.desc}</li>
        `);
    },
    hideLeftSelectedNode: function (data) {
        $("#info-node").html("");
    }
};

function getTree() {
    var tree = [
        {
            text: "<span class='fa fa-home'></span>Parent 1",
            nodeId: "dlewjfkljwf",
            desc: "custom",
            nodes: [
                {
                    text: "Child 1",
                    nodes: [
                        {
                            text: "Grandchild 1"
                        },
                        {
                            text: "Grandchild 2"
                        }
                    ]
                },
                {
                    text: "Child 2"
                }
            ]
        },
        {
            text: "Parent 2",
            icon: "glyphicon glyphicon-stop",
            selectedIcon: "glyphicon glyphicon-stop",
            color: "#000000",
            backColor: "#FFFFFF",
            href: "#node-1",
            selectable: true,
            state: {
                checked: true,
                disabled: true,
                expanded: true,
                selected: false
            },
            tags: ['available'],
        }
    ];

    return tree;
}

$(document).ready(function () {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar, #content').toggleClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });
    
   
    MAIN.init();
});