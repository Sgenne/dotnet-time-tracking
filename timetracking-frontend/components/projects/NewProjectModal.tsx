import Modal from "../utils/Modal"
import styles from "../../styles/projects/NewProjectModal.module.css";
import TransparentCloseButton from "../utils/buttons/TransparentCloseButton";
import ClearTextInput from "../utils/input/ClearTextInput";
import TextArea from "../utils/input/TextArea";
import ControlledStateHandler from "../../types/ControlledStateHandler";

export interface NewProjectModalProps {
    nameStateHandler: ControlledStateHandler<string>;
    descriptionStateHandler: ControlledStateHandler<string>;
}

const NewProjectModal = ({ nameStateHandler, descriptionStateHandler }: NewProjectModalProps) => {
    return (
        <Modal>
            <div className={styles["container"]}>
                <div className={styles["top-section"]}>
                    <h4>New Project</h4>
                    <TransparentCloseButton />
                </div>
                <div className={styles["name-section"]}>
                    <div className={styles["name-label"]}>
                        <label>Name</label>
                    </div>
                    <div className={styles["name-input"]}>
                        <ClearTextInput
                            onChange={nameStateHandler.changeHandler}
                            value={nameStateHandler.value} />
                    </div>
                </div>
                <div className={styles["description-section"]}>
                    <div className={styles["description-label"]}>
                        <label>description</label>
                    </div>
                    <div className={styles["description-input"]}>
                        <TextArea
                            onChange={descriptionStateHandler.changeHandler}
                            value={descriptionStateHandler.value} />
                    </div>
                </div>
            </div>
        </Modal>
    )
}

export default NewProjectModal