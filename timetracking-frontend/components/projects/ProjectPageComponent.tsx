import styles from "../../styles/projects/ProjectPageComponent.module.css";
import PrimaryButton from "../utils/buttons/PrimaryButton";
import PlusIcon from "../utils/icons/PlusIcon";

const ProjectPageComponent = () => {
    return (
        <div className={styles["page-container"]}>
            <div className={styles["top-bar"]}>
                <h2>Projects</h2>
                <span className={styles["new-project-button-container"]}>
                    <PrimaryButton onClick={() => { }}>
                        <>
                            <PlusIcon />
                            <span className={styles["new-project-button__text"]}> New Project</span>
                        </>
                    </PrimaryButton>
                </span>
            </div>
            <div className={styles["projects-list"]}>
                projects here
            </div>
        </div>
    )
}

export default ProjectPageComponent