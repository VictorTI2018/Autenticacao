class ButtonComponent extends HTMLElement {
    constructor() {
        super()

        this.shadow = this.attachShadow({ mode: 'open' })
    }

    get color() {
        return this.getAttribute("color")
    }

    set color(val) {
        this.setAttribute("color", val)
    }

    get hover() {
        return this.getAttribute("hover")
    }

    set hover(val) {
        this.setAttribute("hover", val)
    }

    get hoverBorder() {
        return this.getAttribute("hoverBorder")
    }

    set hoverBorder(val) {
        this.setAttribute("hoverBorder", val)
    }

    get text() {
        return this.getAttribute("text")
    }

    set text(val) {
        this.setAttribute("text", val)
    }

    static get observedAttribute() {
        return ['color', 'text']
    }


    connectedCallback() {
        this.render()
    }

    render() {
        this.shadow.innerHTML = `
            <style>
                .btn {
                    display: inline-block;
                    font-weight: 400;
                    line-height: 1.5;
                    color: #212529;
                    text-align: center;
                    text-decoration: none;
                    vertical-align: middle;
                    cursor: pointer;
                    -webkit-user-select: none;
                    -moz-user-select: none;
                    user-select: none;
                    background-color: transparent;
                    border: 1px solid transparent;
                    padding: 0.2rem 0.75rem;
                    font-size: 1rem;
                    border-radius: 0.25rem;
                    transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
                }
                .btn-primary {
                    color: #fff;
                    background-color: #${this.color};
                    border-color: #${this.color};
                }

                .btn-primary:hover {
                    color: #fff;
                    background-color: #${this.hover};
                    border-color: #${this.hoverBorder};
                }
            </style>
         <button class="btn btn-primary">
                ${this.text}
         </button>
        `
    }
}