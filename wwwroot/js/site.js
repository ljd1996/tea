// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function clearNoNum(obj) {
    //先把非数字的都替换掉，除了数字和.
    obj.value = obj.value.replace(/[^\d.]/g, "");
    //必须保证第一个为数字而不是.
    obj.value = obj.value.replace(/^\./g, "");
    //保证只有出现一个.而没有多个.
    obj.value = obj.value.replace(/\.{2,}/g, ".");
    //保证.只出现一次，而不能出现两次以上
    obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
}

function chooseImg1(obj) {
    var src = handle(obj);
    if (src == null) {
        $(obj).val(null);
    }

    $('#cropedBigImg1').attr('src', src);
}

function handle(img) {
    var filePath = $(img).val();
    var ext = filePath.match(/\.([^.]+)$/)[1];
    var src = window.URL.createObjectURL(img.files[0]); //转成可以在本地预览的格式

    switch (ext) {
        case 'jpg':
        case 'JPG':
        case 'jpeg':
        case 'JPEG':
        case 'png':
        case 'PNG':
            break;
        default:
            alert('请上传图片类型！');
            src = null;
            break;
    }
    var size = img.files[0].size;
    if (size > 1024000) {
        alert('请上传小于1M的图片！');
        src = null;
    }
    return src;
}
