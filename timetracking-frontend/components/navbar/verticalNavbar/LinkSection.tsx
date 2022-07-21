
import styles from "../../../styles/navbar/verticalNavbar/LinkSection.module.css";
import IconLink from "../IconLink";
import ClockIcon from "../../utils/icons/ClockIcon";

const LinkSection = () => {
    return (
        <div className={styles["section-container"]}>
            <h5 className={styles["section-header"]}>Track</h5>
            <ul className={styles["links"]}>
                <li>
                    <IconLink href="#" linkText="Timers" icon={<ClockIcon />} />
                </li>
                <li>Projects</li>
            </ul>
        </div>
    )
}

export default LinkSection