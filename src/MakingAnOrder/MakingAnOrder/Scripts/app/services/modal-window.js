class ModalWindow {
    constructor(selector) {
        this.modalSelector = selector;
    }

    show() {
        $(this.modalSelector).modal('show');
    }

    hide() {
        $(this.modalSelector).modal('hide');
    }

    onShow(shownCallback) {
        $(this.modalSelector).off('shown.bs.modal').on('shown.bs.modal', () => {
            shownCallback();
        });
    }

    onHide(closedCallback) {
        $(this.modalSelector).off('hidden.bs.modal').on('hidden.bs.modal', () => {
            closedCallback();
        });
    }
}