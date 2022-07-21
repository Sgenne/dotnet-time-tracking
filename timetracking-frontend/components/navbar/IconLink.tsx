import Link from "next/link"
import { ReactElement } from "react";
import styles from "../../styles/navbar/IconLink.module.css";

export interface IconLinkProps {
    href: string;
    linkText: string;
    icon: ReactElement;
}

const IconLink = ({ href, linkText, icon }: IconLinkProps) => {
    return (
        <Link href={href}>
            <a className={styles["link"]}>
                <span className={styles["icon"]}>{icon}</span>
                <span className={styles["link-text"]}>{linkText}</span>
            </a>
        </Link>
    )
}

export default IconLink