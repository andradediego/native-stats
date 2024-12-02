class CustomContainer extends HTMLElement {
    constructor() {
        super();
        const shadow = this.attachShadow({ mode: 'open' });
        
        shadow.innerHTML = `
            <style>
                :host {
                    display: block;
                    margin: 0.8rem;
                }

                div {
                    display: flex;
                    justify-content: space-between;
                    align-items: center;
                    margin: 0;
                    border: 1px solid gray;
                    padding: 8px;
                    border-radius: 9px;
                    background-color: var(--background-color, white);
                    box-shadow: var(--box-shadow, 0 4px 6px rgba(0, 0, 0, 0.1));
                }
            </style>
            <div>
                <slot></slot>
            </div>
        `;
    }
}

customElements.define('custom-container', CustomContainer);