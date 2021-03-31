"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Paginator = /** @class */ (function () {
    function Paginator() {
        this.pageSizeOptions = [5, 10, 20, 50, 100];
        this.source = [];
        this.page = [];
        this.length = this.source.length;
        this.index = 0;
        this.pageSize = 5;
    }
    Paginator.prototype.paginate = function (event) {
        this.length = event.length;
        this.pageSize = event.pageSize;
        this.index = event.pageIndex;
        this.update();
    };
    Paginator.prototype.update = function () {
        var start = (this.pageSize * this.index);
        var end = start + this.pageSize;
        this.page = [];
        for (var i = start; i < end && i < this.source.length; i++) {
            this.page.push(this.source[i]);
        }
    };
    Paginator.prototype.pageCount = function () {
        return Math.ceil(this.source.length / this.pageSize);
    };
    return Paginator;
}());
exports.default = Paginator;
//# sourceMappingURL=paginator.js.map