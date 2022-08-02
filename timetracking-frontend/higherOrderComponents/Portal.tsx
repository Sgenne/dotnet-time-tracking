import { ReactElement, useEffect, useState } from "react"
import { createPortal } from "react-dom"

export interface PortalProps {
    children: ReactElement;
}

const Portal = ({ children }: PortalProps) => {
    const [portalContainer, setPortalContainer] = useState<Element>();

    useEffect(() => {
        const containerElement = document.querySelector("#portal");
        setPortalContainer(containerElement ?? undefined);
    }, []);


    if (!portalContainer) return <></>;

    return createPortal(children, portalContainer)
}

export default Portal