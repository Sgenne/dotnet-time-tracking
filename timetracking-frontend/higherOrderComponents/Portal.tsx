import { ReactElement } from "react"
import { createPortal } from "react-dom"

export interface PortalProps {
    children: ReactElement;
}

const Portal = ({ children }: PortalProps) => {
    const portalContainer = document.querySelector("#portal");

    if (!portalContainer) return children;

    return createPortal(children, portalContainer)
}

export default Portal