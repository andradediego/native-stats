class ErrorMessage extends HTMLElement {
    constructor() {
        super();
        const shadow = this.attachShadow({ mode: 'open' });

        shadow.innerHTML = `
            <style>
                .warning {
                    color: red;
                    font-weight: bold;
                }
            </style>
            <div class="warning">
                <slot></slot>
            </div>
        `;
        
    }
}

customElements.define('error-message', ErrorMessage);