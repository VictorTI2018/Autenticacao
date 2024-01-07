class CardComponent extends HTMLElement {
    constructor() {
        super()
        this.shadow = this.attachShadow({ mode: 'open' })

    }

    get title() {
        return this.getAttribute('title')
    }

    set title(val) {
        this.setAttribute('title', val)
    }

    get width () {
        return this.getAttribute('width')
    }

    set width (val) {
        this.setAttribute('width', val)
    }

    static get observedAttribute() {
        return ['title', 'width']
    }


    connectedCallback() {
        this.render();
    }

    render() {
        this.shadow.innerHTML = `
        <style>
        .card {
            width: ${this.width}px;
            position: relative;
            display: flex;
            flex-direction: column;
            min-width: 0;
            word-wrap: break-word;
            background-color: #fff;
            background-clip: border-box;
            border: 1px solid rgba(0,0,0,.125);
            border-radius: 0.25rem;
        }
        
        .card-header:first-child {
            border-radius: calc(0.25rem - 1px) calc(0.25rem - 1px) 0 0;
        }
        
        .card-header {
            padding: 0.5rem 1rem;
            margin-bottom: 0;
            background-color: rgba(0,0,0,.03);
            border-bottom: 1px solid rgba(0,0,0,.125);
        }

        .card-body {
            flex: 1 1 auto;
            padding: 1rem 1rem;
        }

        .card-footer:last-child {
            border-radius: 0 0 calc(0.25rem - 1px) calc(0.25rem - 1px);
        }

        .card-footer {
            padding: 0.5rem 1rem;
            background-color: rgba(0,0,0,.03);
            border-top: 1px solid rgba(0,0,0,.125);
            display: flex;
            align-items:center;
            justify-content: space-around;
        }
        </style>
        
        <div class="card">
                <div class="card-header" id="title">
                    ${this.title}
                </div>
                <div class="card-body" id="body">
                    <slot name="body"></slot>
                </div>
                <div class="card-footer">
                    <slot name="footer"></slot>
                </div>
            </div>`
    }
}