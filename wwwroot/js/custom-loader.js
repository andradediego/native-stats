class CustomLoader extends HTMLElement {
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
                    margin: 1rem 0;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                }

                .loader {
                        width: 48px;
                        height: 48px;
                        border: 5px solid lightskyblue;
                        border-bottom-color: transparent;
                        border-radius: 50%;
                        display: inline-block;
                        box-sizing: border-box;
                        animation: rotation 1s linear infinite;
                    }
                    @keyframes rotation {
                        0% {
                            transform: rotate(0deg);
                        }
                        100% {
                            transform: rotate(360deg);
                        }
                    }
            </style>
            <div aria-hidden="true">
                <span class="loader"></slot>
            </div>
        `;
        
    }
}

customElements.define('custom-loader', CustomLoader);