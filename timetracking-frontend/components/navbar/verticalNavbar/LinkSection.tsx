import styles from "../../../styles/navbar/verticalNavbar/LinkSection.module.css";
import IconLink, { IconLinkProps } from "../IconLink";
import ClockIcon from "../../utils/icons/ClockIcon";
import FolderIcon from "../../utils/icons/FolderIcon";
import { ReactElement } from "react";

export interface LinkSectionProps {
    header: string;
    links: IconLinkProps[];
}

const LinkSection = ({ header, links }: LinkSectionProps) => {

    const iconLinks: ReactElement[] = links.map(linkProps => <li className={styles["link-item"]} key={header + links}>
        <IconLink {...linkProps} />
    </li>)

    return (
        <div className={styles["section-container"]}>
            <h5 className={styles["section-header"]}>{header}</h5>
            <ul className={styles["links"]}>{iconLinks}</ul>
        </div>
    )
}

export default LinkSection