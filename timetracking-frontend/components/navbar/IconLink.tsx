import Link from "next/link"
import { useRouter } from "next/router";
import { ReactElement } from "react";
import styles from "../../styles/navbar/IconLink.module.css";

export interface IconLinkProps {
    href: string;
    linkText: string;
    icon: ReactElement;
}

const IconLink = ({ href, linkText, icon }: IconLinkProps) => {
    const router = useRouter();

    const isActive = router.pathname === href;

    const className = `${styles["link"]} ${isActive ? styles["active-link"] : ""}`

    return (
        <Link href={href}>
            <a className={className}>
                <span className={styles["icon"]}>{icon}</span>
                <span className={styles["link-text"]}>{linkText}</span>
            </a>
        </Link>
    )
}

export default IconLink